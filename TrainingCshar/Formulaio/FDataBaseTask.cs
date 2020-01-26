using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TrainingCshar.Encoder;

namespace TrainingCshar.Formulaio
{
    public partial class FDataBaseTask : Form
    {
        private const string carpeta = @"D:\TrainingDb\";
        private SqlConnection sqlConnection;
        public FDataBaseTask()
        {
            InitializeComponent();
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
            DGPersona.DataSource = CargarDbenBs(sqlConnection);
        }
        private void btnLocalToDb_Click(object sender, EventArgs e)
        {
            GuardarBSenDb(DGPersona);
        }
        private BindingSource CargarCsv()
        {
            BindingSource dgCsv = new BindingSource();

            DataTable dt = new DataTable();

            using (var sr = new StreamReader($"{carpeta}DGPersona_26-01-2020_1243.csv"))
            {
                string[] headers = sr.ReadLine().Split(',');
                foreach (string header in headers)
                {
                    dt.Columns.Add(header);
                }
                dt.Columns[0].ColumnName = "per_idPersona";
                dt.Columns[1].ColumnName = "per_nombre";
                dt.Columns[2].ColumnName = "per_apellido";
                dt.Columns[3].ColumnName = "per_edad";
                dt.Columns[4].ColumnName = "per_rut";
                dt.Columns[5].ColumnName = "per_dv";
                dt.Columns[6].ColumnName = "per_fechaNacimiento";

                dt.Columns["per_edad"].DataType = Type.GetType("System.Byte");
                dt.Columns["per_rut"].DataType = Type.GetType("System.Int32");
                dt.Columns["per_fechaNacimiento"].DataType = Type.GetType("System.DateTime");
                

                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(',');
                    DataRow dr = dt.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        dr[i] = rows[i];
                    }
                    dt.Rows.Add(dr);
                }
            }
            dt.Columns.Remove("per_idPersona");
           

            dgCsv.DataSource = dt;
            return dgCsv;
        }
        private BindingSource CargarDbenBs(SqlConnection sqlConnection)
        {
            BindingSource dgDb = new BindingSource();

            SqlCommand sqlCmd = new SqlCommand("[colegio].[pa_PersonasSegmento]", sqlConnection);

            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add(new SqlParameter("@cantidad", 300));

            DataTable dt = new DataTable();
            dt.Load(sqlCmd.ExecuteReader());
            dgDb.DataSource = dt;
            return dgDb;
        }
        private void DGPersona_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int cantidadFilas = DGPersona.Rows.Count;

            for (int i = 1; i < cantidadFilas; i++)
            {
                DGPersona.Rows[i - 1].Cells[0].Value = i;
            }
        }
        private void FDataBaseTask_FormClosed(object sender, FormClosedEventArgs e)
        {
            sqlConnection.Close();
        }
        private void FDataBaseTask_Load(object sender, EventArgs e)
        {
            Codificacion Codificacion = new Codificacion();

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
        private void GuardarBSenDb(DataGridView dGPersona)
        {
            DataTable dtPersona = GetBindingSource(dGPersona);

            if (dtPersona is null)
            {
                return;
            }

            SqlCommand sqlCmd = new SqlCommand("[colegio].[pa_PersonasEnTabla]", sqlConnection);

            sqlCmd.CommandType = CommandType.StoredProcedure;

            sqlCmd.Parameters.Add("@tabla", SqlDbType.Structured).Value = dtPersona;

           int cantidadAgregadaSql = sqlCmd.ExecuteNonQuery();

            MessageBox.Show($"Se han agregado {cantidadAgregadaSql.ToString()} de registros a la base de datos: {sqlConnection.Database}", "Sql Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

                    for (int j = 0; j < dGPersona.ColumnCount; j++)
                    {
                        columna += dGPersona.Columns[j].HeaderText + ",";
                    }

                    // Para quitar la ultima coma {,}
                    columna = columna.Substring(0, columna.Length - 1);
                    texto.AppendLine(columna);
                    ///<summary>
                    /// Se recorre las filas y se ingresa la informacion en el stringbuilder
                    /// </summary>
                    for (int i = 0; i < dGPersona.RowCount - 1; i++)
                    {
                        string Fila = "";
                        for (int j = 0; j < dGPersona.ColumnCount; j++)
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
            } catch (Exception e)
                {
                MessageBox.Show($"El formato que se intenta exportar no es valido\n{e.TargetSite}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
  }
