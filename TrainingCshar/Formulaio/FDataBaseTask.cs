using CsharLibrary.Class.Data_Process;
using CsharLibrary.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TrainingCshar.Formulaio
{
    public partial class FDataBaseTask : Form
    {
        private IManagement management;
        private string estadoMesanje = "La tabla esta vacia";

        public FDataBaseTask(IManagement _management)
        {
            InitializeComponent();
            InitializeDGPersona();
            management = _management;
        }

        private void btnExportToCsv_Click(object sender, EventArgs e)
        {
            if (DGPersona.RowCount < 1)
            {
                callMessage(estadoMesanje);
                return;
            }

            string pathToSave = ObtainPathToAction(true);

            estadoMesanje = management.SaveCsv((List<Person>)DGPersona.DataSource, pathToSave);

            callMessage(estadoMesanje);
        }

        private void btnLoadCSV_Click(object sender, EventArgs e)
        {
            string pathToLoad = ObtainPathToAction(false);
            DGPersona.DataSource = management.LoadCsv(pathToLoad);
        }

        private void btnLoadDb_Click(object sender, EventArgs e)
        {
            DGPersona.DataSource = management.LoadDB();
        }

        private void btnLocalToDb_Click(object sender, EventArgs e)
        {
            if (DGPersona.RowCount < 1)
            {
                callMessage(estadoMesanje);
                return;
            }
            estadoMesanje = management.SaveDB((List<Person>)DGPersona.DataSource);
            callMessage(estadoMesanje);
        }

        private void DGPersona_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int cantidadFilas = DGPersona.Rows.Count;

            for (int i = 1; i < cantidadFilas; i++)
            {
                DGPersona.Rows[i - 1].Cells[0].Value = i;
            }
        }

        private void InitializeDGPersona()
        {
            DGPersona.DataSource = new List<Person>();
        }

        private void callMessage(string message)
        {
            if (!string.IsNullOrEmpty(message))
                MessageBox.Show(message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private string ObtainPathToAction(bool isSave)
        {
            string path = management.GetRootDirectory();

            if (isSave)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog()
                {
                    InitialDirectory = path,
                    Title = "Guardar archivo persona...",
                    Filter = "Archivos csv (*.csv)|*.csv",
                    FilterIndex = 1,
                    FileName = management.GetDefaultFileName(),
                    RestoreDirectory = true
                };
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    path = saveFileDialog.FileName;
            }
            else
            {
                OpenFileDialog openFileDialog = new OpenFileDialog()
                {
                    InitialDirectory = path,
                    Title = "Abrir archivo persona...",
                    Filter = "Archivos csv (*.csv)|*.csv",
                    FilterIndex = 1,
                    RestoreDirectory = true
                };
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                    path = openFileDialog.FileName;
            }
            return path;
        }
    }
}