using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TrainingCshar.Class.Data_Process;
using TrainingCshar.Models;

namespace TrainingCshar.Formulaio
{
    public partial class FDataBaseTask : Form
    {
        private const string carpeta = @"D:\TrainingDb\";
        private IGestion gestion;

        public FDataBaseTask()
        {
            InitializeComponent();
            InitializeDGPersona();
            gestion = new Gestion();

        }

        private void btnExportToCsv_Click(object sender, EventArgs e)
        {
            gestion.GuardarEnCsv((List<Persona>)DGPersona.DataSource);
        }

        private void btnLoadCSV_Click(object sender, EventArgs e)
        {
            DGPersona.DataSource = gestion.CargarEnCsv();
        }

        private void btnLoadDb_Click(object sender, EventArgs e)
        {
            DGPersona.DataSource = gestion.CargarEnDB();
        }

        private void btnLocalToDb_Click(object sender, EventArgs e)
        {
            gestion.GuardarEnDB((List<Persona>)DGPersona.DataSource);
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
            DGPersona.DataSource = new List<Persona>();
        }
    }
}