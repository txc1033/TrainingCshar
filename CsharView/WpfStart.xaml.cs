using CsharLibrary;
using CsharLibrary.Class.Data_Process;
using CsharLibrary.Examples;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Windows;
using TrainingCshar.Formulaio;

namespace CsharView
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Container container;
        private IOrchestrator orchestrator;

        public MainWindow()
        {
            Service service = new Service();
            container = service.csharContainer;
            orchestrator = container.GetInstance<IOrchestrator>();
            InitializeComponent();
            InitializeCombobox();
        }

        private void InitializeCombobox()
        {
            cmbAcciones.Items.Add("Seleccione Una Accion...");
            cmbAcciones.SelectedIndex = 0;
            List<string> actions = orchestrator.GetActions();
            foreach (var action in actions)
            {
                cmbAcciones.Items.Add(action);
            }
        }

        private void BtnEjecutarClick(object sender, RoutedEventArgs e)
        {
            txtResultado.Clear();
            string accion = cmbAcciones.Text;
            List<string> resultados = orchestrator.ExecuteAction(accion);
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

        private void OpenFApi()
        {
            WpfClientRestTask fApi = new WpfClientRestTask(container.GetInstance<IManagement>());
            this.Hide();
            fApi.ShowDialog();
            this.Show();
        }

        private void OpenFDb()
        {
            WpfDataBaseTask fDB = new WpfDataBaseTask(container.GetInstance<IManagement>());
            this.Hide();
            fDB.ShowDialog();
            this.Show();
        }

        private void btnForm_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FStart fst = new FStart(container);
            fst.ShowDialog();
            this.Show();
        }
    }
}