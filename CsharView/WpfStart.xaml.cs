using System;
using System.Windows;
using System.Collections.Generic;
using TrainingCshar.Examples;
using TrainingCshar.Formulaio;


namespace CsharView
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Orquestador orquestador;
        public MainWindow()
        {
            orquestador = new Orquestador();
            InitializeComponent();
            InitializeCombobox();
        }

        private void InitializeCombobox()
        {
            cmbAcciones.Items.Add("Seleccione Una Accion...");
            cmbAcciones.SelectedIndex = 0;
            List<string> acciones = orquestador.GetAcciones();
            foreach (var accion in acciones)
            {
                cmbAcciones.Items.Add(accion);
            }
        }

        private void BtnEjecutarClick(object sender, RoutedEventArgs e)
        {
            txtResultado.Clear();
            string accion = cmbAcciones.Text;
            List<string> resultados = orquestador.EjecutaAccion(accion);
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
           WpfClientRestTask fApi = new WpfClientRestTask();
            this.Hide();
            fApi.ShowDialog();
            this.Show();
        }

        private void OpenFDb()
        {
            WpfDataBaseTask fDB = new WpfDataBaseTask();
            this.Hide();
            fDB.ShowDialog();
            this.Show();
        }

        private void btnForm_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            FStart fst = new FStart();
            fst.ShowDialog();
            this.Show();
        }


    }
}
