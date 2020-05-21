﻿using System;
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
using System.Globalization;
using TrainingCshar.Encoder;
using System.Threading;

namespace CsharView
{
    /// <summary>
    /// Lógica de interacción para WpfDataBaseTask.xaml
    /// </summary>
    public partial class WpfDataBaseTask : Window
    {
        private const string carpeta = @"D:\TrainingDb\";
        private const string titulo = "Error";
        private const string formatDate = "dd-MM-yyyy HH:mm:ss";
        private SqlConnection sqlConnection;
        private CultureInfo currentCulture = CultureInfo.CurrentCulture;

        public WpfDataBaseTask()
        {
            InitializeComponent();
            sqlConnection = new SqlConnection(Codificacion.Cadena());
            try
            {
                SqlAccess sql = new SqlAccess();
                Codificacion.Procesar(sql.db, false);
                sqlConnection.Open();
            }
            catch (Exception)
            {
                this.Close();
            }
        }

        private void btnLoadDb_Click(object sender, RoutedEventArgs e)
        {
            DGPersona.ItemsSource = CargarDB(sqlConnection);
            ActualizaNombreColumnasDGPersona(DGPersona.Columns.Count);
        }

        private void btnLoadCSV_Click(object sender, RoutedEventArgs e)
        {
            DGPersona.ItemsSource = CargarCsv();
            ActualizaNombreColumnasDGPersona(DGPersona.Columns.Count);
        }

        private void btnSaveCSV_Click(object sender, RoutedEventArgs e)
        {
            if (DGPersona.Items.Count > 1)
                GuardarCsv(DGPersona);
            else
                MessageBox.Show($"No puedes guardar una tabla vacia!!", titulo, MessageBoxButton.OK);
        }

        private void btnSaveDb_Click(object sender, RoutedEventArgs e)
        {
            if (DGPersona.Items.Count > 1)
                GuardaDGenDB(DGPersona);
            else
                MessageBox.Show($"No puedes exportar una tabla vacia!!", titulo, MessageBoxButton.OK);
        }

        private ObservableCollection<Persona> CargarDB(SqlConnection sqlConnection)
        {
            ObservableCollection<Persona> personasDb = new ObservableCollection<Persona>();

            var seed = Environment.TickCount;
            var random = new Random(seed);
            int rango = random.Next(50, 500);

            DataTable dt = new DataTable();

            SqlCommand sqlCmd = new SqlCommand("[colegio].[pa_PersonasSegmento]", sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.Add(new SqlParameter("@cantidad", rango));

           
            dt.Load(sqlCmd.ExecuteReader());
            int contador = 1;
            foreach (DataRow rows in dt.Rows)
            {


              Persona persona =  new Persona()
                {
                    per_idPersona = contador,
                    per_nombre = rows[0].ToString(),
                    per_apellido = rows[1].ToString(),
                    per_edad = int.Parse(rows[2].ToString(),currentCulture),
                    per_rut = int.Parse(rows[3].ToString(),currentCulture),
                    per_dv = rows[4].ToString(),
                    per_fechaNacimiento = DateTime.Parse(rows[5].ToString(),currentCulture)
              };
                personasDb.Add(persona);
                contador++;
            }


            return personasDb;
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
                using (StreamReader sr = new StreamReader(buscaArchivo.FileName))
                {
                    try
                    {
                        while (!sr.EndOfStream)
                        {

                            string[] rows = sr.ReadLine().Split(',');
                            if (!rows[0].ToString(currentCulture).Equals("ID",StringComparison.CurrentCulture) && !string.IsNullOrEmpty(rows[0].ToString(currentCulture)))
                            {
                                Persona per = new Persona()
                                {
                                    per_idPersona = int.Parse(rows[0],currentCulture),
                                    per_nombre = rows[1],
                                    per_apellido = rows[2],
                                    per_edad = int.Parse(rows[3],currentCulture),
                                    per_rut = int.Parse(rows[4],currentCulture),
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

        private void GuardaDGenDB(DataGrid dGPersona)
        {
            try
            {
                DataTable dtPersona = new DataTable();
                dtPersona.Columns.Add("per_nombre", typeof(string));
                dtPersona.Columns.Add("per_apellido", typeof(string));
                dtPersona.Columns.Add("per_edad", typeof(int));
                dtPersona.Columns.Add("per_rut", typeof(int));
                dtPersona.Columns.Add("per_dv", typeof(char));
                dtPersona.Columns.Add("per_fechaNacimiento", typeof(DateTime));

                foreach (var item in dGPersona.Items)
                {
                    DataGridRow row = (DataGridRow)dGPersona.ItemContainerGenerator.ContainerFromItem(item);
                    if (row == null)
                        continue;
                    var fila = dtPersona.NewRow();
                    for (int j = 1; j < dGPersona.Columns.Count; j++)
                    {
                        FrameworkElement dato = dGPersona.Columns[j].GetCellContent(row);
                        string tipo = dtPersona.Columns[j - 1].DataType.Name.ToLower(currentCulture);
                        string datoText = ((TextBlock)dato).Text;
                        if (!string.IsNullOrEmpty(datoText))
                        {
                            switch (tipo)
                            {
                                case "int32":
                                    fila[j - 1] = Int32.Parse(datoText, currentCulture);
                                    break;
                                case "char":
                                    fila[j - 1] = Char.Parse(datoText);
                                    break;
                                case "datetime":
                                    fila[j - 1] = DateTime.Parse(datoText, currentCulture);
                                    break;

                                default:
                                    fila[j - 1] = datoText;
                                    break;
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(fila[0].ToString()))
                        dtPersona.Rows.Add(fila);
                }

                if (dtPersona is null)
                {
                    return;
                }
                dtPersona.Rows.RemoveAt(dtPersona.Rows.Count - 1);
                SqlCommand sqlCmd = new SqlCommand("[colegio].[pa_PersonasEnTabla]", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCmd.Parameters.Add("@tabla", SqlDbType.Structured).Value = dtPersona;

                int cantidadAgregadaSql = sqlCmd.ExecuteNonQuery();

                MessageBox.Show($"Se han agregado {cantidadAgregadaSql} de registros a la base de datos: {sqlConnection.Database}", titulo, MessageBoxButton.OK);
            }
            catch (Exception e)
            {
                MessageBox.Show($"El formato que se intenta exportar no es valido\n{e.TargetSite}", titulo, MessageBoxButton.OK);
            }

        }

        private void GuardarCsv(DataGrid dGPersona)
        {

            try
            {
                if (DGPersona.Items.Count > 1)
                {
                    string archivo = $"{DGPersona.Name}_{DateTime.Now.ToString("dd-MM-yyyy_HHmm", currentCulture)}.csv";
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
                        if (row == null)
                            continue;

                        for (int j = 0; j < dGPersona.Columns.Count; j++)
                        {
                            FrameworkElement dato = dGPersona.Columns[j].GetCellContent(row);
                            string datoText = ((TextBlock)dato).Text;
                            string internalColumna = dGPersona.Columns[j].Header.ToString();
                            if (!string.IsNullOrEmpty(datoText))
                                Fila += datoText + ",";
                        }
                        if (Fila.Length > 0)
                            Fila = Fila.Substring(0, Fila.Length - 1);
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
            }
        }

        private void DGPersona_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(DateTime))
                (e.Column as DataGridTextColumn).Binding.StringFormat = formatDate;
        }

        private void ActualizaNombreColumnasDGPersona(int cantidadColumnas)
        {
            if (cantidadColumnas > 0)
            {
                DGPersona.Columns[0].Header = "ID";
                DGPersona.Columns[1].Header = "Nombre";
                DGPersona.Columns[2].Header = "Apellidos";
                DGPersona.Columns[3].Header = "Edad";
                DGPersona.Columns[4].Header = "Rut";
                DGPersona.Columns[5].Header = "Digito Verificador";
                DGPersona.Columns[6].Header = "Fecha Nacimiento";
            }
        }
    }
}
