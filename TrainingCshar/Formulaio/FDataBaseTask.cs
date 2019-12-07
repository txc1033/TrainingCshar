using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrainingCshar.Encoder;

namespace TrainingCshar.Formulaio
{
    public partial class FDataBaseTask : Form
    {

       private SqlConnection sqlConnection;
        public FDataBaseTask()
        {
            InitializeComponent();
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

        private void FDataBaseTask_FormClosed(object sender, FormClosedEventArgs e)
        {
            sqlConnection.Close();
        }

        private void DGPersona_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int cantidadFilas = DGPersona.Rows.Count;

            for (int i = 1; i < cantidadFilas; i++)
            {
                DGPersona.Rows[i-1].Cells[0].Value = i;
            }

            
        }

        private void btnLocalToDb_Click(object sender, EventArgs e)
        {
            GuardarBSenDb(DGPersona);
        }

        private void GuardarBSenDb(DataGridView dGPersona)
        {

            throw new NotImplementedException("Metodo en desarrollo");
            
        }

        private void btnLoadDb_Click(object sender, EventArgs e)
        {
            DGPersona = CargarDbenBs(sqlConnection);
        }

        private DataGridView CargarDbenBs(SqlConnection sqlConnection)
        {
            DataGridView dgDb = new DataGridView();

            return dgDb;
        }

        private void btnLoadCSV_Click(object sender, EventArgs e)
        {
            DGPersona = CargarCsv();
        }

        private DataGridView CargarCsv()
        {
            DataGridView dgCsv = new DataGridView();



            return dgCsv;
        }

        private void btnExportToCsv_Click(object sender, EventArgs e)
        {
            GuardarCsv(DGPersona);
        }

        private void GuardarCsv(DataGridView dGPersona)
        {
            string archivo = $"{DGPersona.Name}_{DateTime.UtcNow.ToString("DD-MM-yyyy_hhmm")}.csv";

            throw new NotImplementedException("Metodo en desarrollo");
        }
    }



}
