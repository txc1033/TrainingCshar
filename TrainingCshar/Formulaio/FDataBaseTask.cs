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
        private const string carpeta = @"D:\TrainingDb";
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
            DGPersona = CargarCsv();
        }

        private void btnLoadDb_Click(object sender, EventArgs e)
        {
            DGPersona.DataSource = CargarDbenBs(sqlConnection);
        }

        private void btnLocalToDb_Click(object sender, EventArgs e)
        {
            GuardarBSenDb(DGPersona);
        }

        private DataGridView CargarCsv()
        {
            DataGridView dgCsv = new DataGridView();

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
            if (DGPersona.RowCount > 1)
            {
                string archivo = $"{DGPersona.Name}_{DateTime.UtcNow.ToString("DD-MM-yyyy_hhmm")}.csv";
                StringBuilder texto = new StringBuilder(100);
                string columna = "";

                for (int j = 0; j < DGPersona.ColumnCount; j++)
                {
                    columna += DGPersona.Columns[j].HeaderText + ",";
                }

                // Para quitar la ultima coma {,}
                columna = columna.Substring(0, columna.Length - 1);
                texto.AppendLine(columna);
                ///<summary>
                /// Se recorre las filas y se ingresa la informacion en el stringbuilder
                /// </summary>
                for (int i = 0; i < DGPersona.RowCount - 1; i++)
                {
                    string Fila = "";
                    for (int j = 0; j < DGPersona.ColumnCount; j++)
                    {
                        Fila += DGPersona.Rows[i].Cells[j].Value.ToString() + ",";
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

        private DataTable GetBindingSource(DataGridView dgv)
        {
            BindingSource ds = (BindingSource) dgv.DataSource;

            if (ds is null) {
                return null;
            }
            DataTable dsc = (DataTable)ds.DataSource;

            return dsc;
        }


    }
}