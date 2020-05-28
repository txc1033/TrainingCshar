using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TrainingCshar.Data_Process;
using TrainingCshar.Models;

namespace TrainingCshar.Formulaio
{
    public partial class FDataBaseTask : Form
    {
        private const string carpeta = @"D:\TrainingDb\";
        private GestionFile gestionFile;
        private GestionDB gestionDb;

        public FDataBaseTask()
        {
            InitializeComponent();
            gestionFile = new GestionFile();
            gestionDb = new GestionDB();
            var persona = new List<Persona>()
            {
                new Persona
                {
                    per_nombre = "",
                    per_apellido = "",
                    per_dv = "",
                    per_rut = 0,
                    per_edad = 0,
                    per_idPersona = 0,
                    per_fechaNacimiento = DateTime.MinValue
                }
            };
            DGPersona.DataSource = persona;
        }

        private void btnExportToCsv_Click(object sender, EventArgs e)
        {
            gestionFile.GuardarEnCsv((List<Persona>)DGPersona.DataSource);
        }

        private void btnLoadCSV_Click(object sender, EventArgs e)
        {
            DGPersona.DataSource = gestionFile.CargarEnCsv();
        }

        private void btnLoadDb_Click(object sender, EventArgs e)
        {
            DGPersona.DataSource = gestionDb.CargarEnDB();
        }

        private void btnLocalToDb_Click(object sender, EventArgs e)
        {
            gestionDb.GuardarEnDB((List<Persona>)DGPersona.DataSource);
        }

        private void DGPersona_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int cantidadFilas = DGPersona.Rows.Count;

            for (int i = 1; i < cantidadFilas; i++)
            {
                DGPersona.Rows[i - 1].Cells[0].Value = i;
            }
        }
    }
}