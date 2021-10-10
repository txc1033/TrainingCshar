using CsharLibrary.Class.Data_Process;
using CsharLibrary.Examples;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TrainingCshar.Formulaio
{
    public partial class FStart : Form
    {
        private IOrchestrator orquestador;
        private Container container;

        public FStart(Container _container)
        {
            container = _container;
            orquestador = container.GetInstance<IOrchestrator>();
            InitializeComponent();
            InitializeCombobox();
        }

        private void BtnEjecutar_Click(object sender, EventArgs e)
        {
            txtResultado.Clear();
            string accion = cmbAcciones.Text;
            List<string> resultados = orquestador.ExecuteAction(accion);
            foreach (string resultado in resultados)
            {
                txtResultado.Text += $"{resultado} {Environment.NewLine}";
            }

            switch (accion)
            {
                case "Json":
                    OpenFApi();
                    break;

                case "BaseDatos":
                    if (txtResultado.Text.Contains("Open"))
                    {
                        OpenFDb();
                    }
                    break;
            }
        }

        private void CmbAccion_Click(object sender, EventArgs e)
        {
            cmbAcciones.SelectAll();
        }

        private void CmbAccion_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            cmbAcciones.SelectAll();
        }

        private void CmbAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEjecutar.Enabled = cmbAcciones.SelectedIndex > 0 ? true : false;
        }

        private void CmbAcciones_TextChanged(object sender, EventArgs e)
        {
            int posicionAccion = cmbAcciones.FindString(cmbAcciones.Text);
            int indiceAcciones = posicionAccion > 0 ? posicionAccion : 0;
            cmbAcciones.SelectedIndex = indiceAcciones;
            btnEjecutar.Text = indiceAcciones > 0 ? $"Ejecutar: {cmbAcciones.Text}" : "Ejecutar: Nada";
        }

        private void InitializeCombobox()
        {
            cmbAcciones.Items.Add("Seleccione Una Accion...");
            cmbAcciones.SelectedIndex = 0;
            List<string> actions = orquestador.GetActions();
            foreach (var action in actions)
            {
                cmbAcciones.Items.Add(action);
            }
        }

        private void OpenFApi()
        {
            FApiTask fApi = new FApiTask(container.GetInstance<IManagement>());
            this.Hide();
            fApi.ShowDialog();
            this.Show();
        }

        private void OpenFDb()
        {
            FDataBaseTask fDB = new FDataBaseTask(container.GetInstance<IManagement>());
            this.Hide();
            fDB.ShowDialog();
            this.Show();
        }
    }
}