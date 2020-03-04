using System;
using System.Collections;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Windows;
using TrainingCshar.Models;
using System.IO;
using System.Data;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Diagnostics;
using System.Text;

namespace CsharView
{
    /// <summary>
    /// Lógica de interacción para WpfDataBaseTask.xaml
    /// </summary>
    public partial class WpfDataBaseTask : Window
    {
        private const string carpeta = @"D:\TrainingDb\";
        private const string titulo = "Error";
        private SqlConnection sqlConnection;

        public WpfDataBaseTask()
        {
            InitializeComponent();
        }

        private void btnSaveCSV_Click(object sender, RoutedEventArgs e)
        {
            GuardarCsv(DGPersona);
        }

        private void GuardarCsv(DataGrid dGPersona)
        {
          
                try
                {
                    if (DGPersona.Items.Count > 1)
                    {
                        string archivo = $"{DGPersona.Name}_{DateTime.Now.ToString("dd-MM-yyyy_HHmm")}.csv";
                        StringBuilder texto = new StringBuilder(100);
                        string columna = "";
                        int countColumns = dGPersona.Columns.Count;
                        for (int j = 0; j < countColumns; j++)
                        {
                            columna += dGPersona.Columns[j].Header + ",";
                        }

                        // Para quitar la ultima coma {,}
                        columna = columna.Substring(0, columna.Length - 1);
                        texto.AppendLine(columna);
                    ///<summary>
                    /// Se recorre las filas y se ingresa la informacion en el stringbuilder
                    /// </summary>
                    foreach (var item in dGPersona.Items)
                    {
                        DataGridRow row = (DataGridRow)dGPersona.ItemContainerGenerator.ContainerFromItem(item);
                        string Fila = "";
                        for (int j = 0; j < dGPersona.Columns.Count; j++)
                        {
                            Fila += ((TextBlock)dGPersona.Columns[j].GetCellContent(row)).Text + ",";
                        }
                        Fila = Fila.Substring(0, Fila.Length - 1);
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
                }
        }

        private void btnLoadCSV_Click(object sender, RoutedEventArgs e)
        {
            DGPersona.ItemsSource = CargarCsv();
            DGPersona.Columns[0].Header = "ID";
            DGPersona.Columns[1].Header = "Nombre";
            DGPersona.Columns[2].Header = "Apellidos";
            DGPersona.Columns[3].Header = "Edad";
            DGPersona.Columns[4].Header = "Rut";
            DGPersona.Columns[5].Header = "Digito Verificador";
            DGPersona.Columns[6].Header = "Fecha Nacimiento";
        }

        private void btnSaveDb_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLoadDb_Click(object sender, RoutedEventArgs e)
        {

        }

        private ObservableCollection<Persona> CargarCsv()
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
                using (var sr = new StreamReader(buscaArchivo.FileName))
                {
                    try
                    {
                        while (!sr.EndOfStream)
                        {

                            string[] rows = sr.ReadLine().Split(',');
                            if (rows[0] != "ID")
                            {
                                Persona per = new Persona()
                                {
                                    per_idPersona = int.Parse(rows[0]),
                                    per_nombre = rows[1],
                                    per_apellido = rows[2],
                                    per_edad = int.Parse(rows[3]),
                                    per_rut = int.Parse(rows[4]),
                                    per_dv = rows[5],
                                    per_fechaNacimiento = DateTime.Parse(rows[6])

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

    }
}
