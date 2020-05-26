using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TrainingCshar.Encoder;
using TrainingCshar.Data_Process;
using System.Collections.Generic;
using TrainingCshar.Models;

namespace TrainingCshar.Formulaio
{
    public partial class FDataBaseTask : Form
    {
        private const string carpeta = @"D:\TrainingDb\";
        private SqlConnection sqlConnection;
        private GestionFile gestionFile;
        private GestionDB gestionDb;
        public FDataBaseTask()
        {
            InitializeComponent();
            gestionFile = new GestionFile();
            gestionDb = new GestionDB();
        }

        private void btnExportToCsv_Click(object sender, EventArgs e)
        {
            GuardarCsv(DGPersona);
        }
        private void btnLoadCSV_Click(object sender, EventArgs e)
        {
            DGPersona.DataSource = CargarCsv();
        }


        private void btnLoadDb_Click(object sender, EventArgs e)
        {
            DGPersona.DataSource = gestionDb.CargarEnDB();
        }
        private void btnLocalToDb_Click(object sender, EventArgs e)
        {
            gestionDb.GuardarEnDB((List<Persona>)DGPersona.DataSource);
        }


        private BindingSource CargarCsv()
        {
            BindingSource dgCsv = new BindingSource();

            DataTable dataTable = new DataTable();

            OpenFileDialog buscaArchivo = new OpenFileDialog
            {
                InitialDirectory = carpeta,
                Title = "Abrir archivo persona...",
                Filter = "Archivos csv (*.csv)|*.csv",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            if (buscaArchivo.ShowDialog() == DialogResult.OK)
            {
                using (var sr = new StreamReader(buscaArchivo.FileName))
                {
                    try
                    {
                        string[] headers = sr.ReadLine().Split(',');
                        foreach (string header in headers)
                        {
                            dataTable.Columns.Add(header);
                        }
                        dataTable.Columns[0].ColumnName = "per_idPersona";
                        dataTable.Columns[1].ColumnName = "per_nombre";
                        dataTable.Columns[2].ColumnName = "per_apellido";
                        dataTable.Columns[3].ColumnName = "per_edad";
                        dataTable.Columns[4].ColumnName = "per_rut";
                        dataTable.Columns[5].ColumnName = "per_dv";
                        dataTable.Columns[6].ColumnName = "per_fechaNacimiento";
                        dataTable.Columns["per_edad"].DataType = Type.GetType("System.Byte");
                        dataTable.Columns["per_rut"].DataType = Type.GetType("System.Int32");
                        dataTable.Columns["per_fechaNacimiento"].DataType = Type.GetType("System.DateTime");
                        //Se escribe las filas en las columnas
                        while (!sr.EndOfStream)
                        {
                            string[] rows = sr.ReadLine().Split(',');
                            DataRow dr = dataTable.NewRow();
                            int countHeader = headers.Length;
                            for (int i = 0; i < countHeader; i++)
                            {
                                dr[i] = rows[i];
                            }
                            dataTable.Rows.Add(dr);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show($"Error el formato del archivo no es compatible con la tabla\n{e.TargetSite}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
                dataTable.Columns.Remove("per_idPersona");
                dgCsv.DataSource = dataTable;
            }

            return dgCsv;
        }
        private void GuardarCsv(DataGridView dGPersona)
        {
            try
            {
                if (dGPersona.RowCount > 1)
                {
                    string archivo = $"{DGPersona.Name}_{DateTime.Now.ToString("dd-MM-yyyy_HHmm")}.csv";
                    StringBuilder texto = new StringBuilder(100);
                    string columna = "";
                    int countColumns = dGPersona.ColumnCount;
                    for (int j = 0; j < countColumns; j++)
                    {
                        columna += dGPersona.Columns[j].HeaderText + ",";
                    }

                    // Para quitar la ultima coma {,}
                    columna = columna.Substring(0, columna.Length - 1);
                    texto.AppendLine(columna);
                    ///<summary>
                    /// Se recorre las filas y se ingresa la informacion en el stringbuilder
                    /// </summary>
                    int countRows = dGPersona.RowCount - 1;
                    for (int i = 0; i < countRows; i++)
                    {
                        string Fila = "";
                        int countColumn = dGPersona.ColumnCount;
                        for (int j = 0; j < countColumn; j++)
                        {
                            Fila += dGPersona.Rows[i].Cells[j].Value.ToString() + ",";
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
                MessageBox.Show($"El formato que se intenta exportar no es valido\n{e.TargetSite}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DGPersona_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int cantidadFilas = DGPersona.Rows.Count;

            for (int i = 1; i < cantidadFilas; i++)
            {
                DGPersona.Rows[i - 1].Cells[0].Value = i;
            }
        }
        private DataTable GetBindingSource(DataGridView dgv)
        {
            BindingSource ds = (BindingSource)dgv.DataSource;

            if (ds is null)
            {
                return null;
            }
            DataTable dsc = (DataTable)ds.DataSource;

            return dsc;
        }

    }
}
