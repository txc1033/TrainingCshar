using System;
using System.Collections.ObjectModel;
using System.Windows;
using TrainingCshar.Models;
using System.IO;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Diagnostics;
using System.Text;
using System.Globalization;

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

        /// <summary>
        /// Apartado para wpf
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Persona> CargarCsv()
        {
            return _CargarCsv();
        } 
        public bool GuardarCsv(DataGrid dGPersona)
        {
            return _GuardarCsv(dGPersona);
        }
        private ObservableCollection<Persona> _CargarCsv()
        {
            ObservableCollection<Persona> personasCsv = new ObservableCollection<Persona>();
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
        private bool _GuardarCsv(DataGrid dGPersona)
        {

            try
            {
                if (dGPersona.Items.Count > 1)
                {
                    string archivo = $"{dGPersona.Name}_{DateTime.Now.ToString("dd-MM-yyyy_HHmm", currentCulture)}.csv";
                    StringBuilder texto = new StringBuilder(2655, 28000);
                    string columna = "";
                    int countColumns = dGPersona.Columns.Count;
                    for (int j = 0; j < countColumns; j++)
                    {
                        columna += dGPersona.Columns[j].Header + (j < countColumns - 1 ? "," : "");
                    }

                    texto.AppendLine(columna);
                    ///<summary>
                    /// Se recorre las filas y se ingresa la informacion en el stringbuilder
                    /// </summary>
                    foreach (var item in dGPersona.Items)
                    {
                        DataGridRow row = (DataGridRow)dGPersona.ItemContainerGenerator.ContainerFromItem(item);
                        string Fila = "";
                        if (row == null)
                            continue;
                        int countFilas = dGPersona.Columns.Count;
                        for (int j = 0; j < countFilas; j++)
                        {
                            FrameworkElement dato = dGPersona.Columns[j].GetCellContent(row);
                            string datoText = ((TextBlock)dato).Text;
                            if (!string.IsNullOrEmpty(datoText))
                                Fila += datoText + (j < countFilas - 1 ? "," : "");
                        }
                        if (!string.IsNullOrEmpty(Fila))
                            texto.AppendLine(Fila);

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
            }
            catch (Exception e)
            {
                MessageBox.Show($"El formato que se intenta exportar no es valido\n{e.TargetSite}", titulo, MessageBoxButton.OK);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Apartado para form
        /// </summary>
        /// <returns></returns>


    }
}
