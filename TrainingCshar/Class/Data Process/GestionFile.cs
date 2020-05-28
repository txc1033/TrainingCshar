using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows;
using TrainingCshar.Models;

namespace TrainingCshar.Data_Process
{
    public class GestionFile : IGestionFile
    {
        private const string carpeta = @"D:\TrainingDb\";
        private const string titulo = "Error";
        private CultureInfo currentCulture = CultureInfo.CurrentCulture;

        public GestionFile()
        {
        }

        public List<Persona> CargarEnCsv()
        {
            return _CargarEnCsv();
        }

        public bool GuardarEnCsv(List<Persona> personas)
        {
            return _GuardarEnCsv(personas);
        }

        private List<Persona> _CargarEnCsv()
        {
            List<Persona> personasCsv = new List<Persona>();
            OpenFileDialog buscaArchivo = new OpenFileDialog
            {
                InitialDirectory = carpeta,
                Title = "Abrir archivo persona...",
                Filter = "Archivos csv (*.csv)|*.csv",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (buscaArchivo.ShowDialog() == true)
            {
                using (StreamReader sr = new StreamReader(buscaArchivo.FileName))
                {
                    try
                    {
                        while (!sr.EndOfStream)
                        {
                            string[] rows = sr.ReadLine().Split(',');
                            if (!rows[0].ToString(currentCulture).Equals("ID", StringComparison.CurrentCulture) && !string.IsNullOrEmpty(rows[0].ToString(currentCulture)))
                            {
                                Persona per = new Persona()
                                {
                                    per_idPersona = int.Parse(rows[0], currentCulture),
                                    per_nombre = rows[1],
                                    per_apellido = rows[2],
                                    per_edad = int.Parse(rows[3], currentCulture),
                                    per_rut = int.Parse(rows[4], currentCulture),
                                    per_dv = rows[5],
                                    per_fechaNacimiento = DateTime.Parse(rows[6], currentCulture)
                                };
                                personasCsv.Add(per);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"Error el formato del archivo no es " +
                                        $"compatible con la tabla\n{e.TargetSite}", titulo, MessageBoxButton.OK);
                        return null;
                    }
                }
            }

            return personasCsv;
        }

        private bool _GuardarEnCsv(List<Persona> personas)
        {
            try
            {
                if (personas.Count > 1)
                {
                    string archivo = $"DGPersona_{DateTime.Now.ToString("dd-MM-yyyy_HHmm", currentCulture)}.csv";
                    StringBuilder texto = new StringBuilder(2655, 28000);
                    string columna = "ID,Nombre,Apellidos,Edad,Rut,Digito Verificador,Fecha Nacimiento";

                    texto.AppendLine(columna);
                    ///<summary>
                    /// Se recorre las filas y se ingresa la informacion en el stringbuilder
                    /// </summary>
                    int contador = 1;
                    foreach (var persona in personas)
                    {
                        string fila = $"{contador},{persona.per_nombre},{persona.per_apellido},";
                        fila += $"{persona.per_edad},{persona.per_rut},{persona.per_dv},{persona.per_fechaNacimiento}";
                        if (!string.IsNullOrEmpty(fila))
                            texto.AppendLine(fila);

                        contador++;
                    }
                    ///<summary>
                    /// Aqui una vez estructurado el cuerpo del csv procedemos a guardarlo
                    /// pasamos la ruta en la que deseamos guardar el archivo
                    /// </summary>

                    if (!Directory.Exists(carpeta))
                    {
                        Directory.CreateDirectory(carpeta);
                    }
                    string rutaArchivo = Path.Combine(carpeta, archivo);
                    File.WriteAllText(rutaArchivo, texto.ToString());

                    ///<summary>
                    /// Una vez guardado lo abrimos con un editor de texto para
                    /// verificar que contenga la informacion
                    /// </summary>
                    try
                    {
                        Process.Start("notepad++.exe", rutaArchivo);
                    }
                    catch (Exception)
                    {
                        Process.Start("notepad.exe", rutaArchivo);
                    }
                }
                else
                {
                    MessageBox.Show($"La tabla no tiene suficientes datos para exportarse", titulo, MessageBoxButton.OK);
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show($"El formato que se intenta exportar no es valido\n{e.TargetSite}", titulo, MessageBoxButton.OK);
                return false;
            }
            return true;
        }
    }
}