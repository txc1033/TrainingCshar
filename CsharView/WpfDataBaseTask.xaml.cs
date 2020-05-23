using System;
using System.Windows;
using System.Windows.Controls;
using TrainingCshar.Data_Process;

namespace CsharView
{
    /// <summary>
    /// Lógica de interacción para WpfDataBaseTask.xaml
    /// </summary>
    public partial class WpfDataBaseTask : Window
    {
        private const string formatDate = "dd-MM-yyyy HH:mm:ss";
        private GestionFile gestionFile;
        private GestionDB gestionDb;

        public WpfDataBaseTask()
        {
            InitializeComponent();
            gestionFile = new GestionFile();
            gestionDb = new GestionDB();
            
        }

        private void btnLoadDb_Click(object sender, RoutedEventArgs e)
        {
            DGPersona.ItemsSource = gestionDb.CargarDB();
            ActualizaNombreColumnasDGPersona(DGPersona.Columns.Count);
        }

        private void btnLoadCSV_Click(object sender, RoutedEventArgs e)
        {
            DGPersona.ItemsSource = gestionFile.CargarCsv();
            ActualizaNombreColumnasDGPersona(DGPersona.Columns.Count);
        }

        private void btnSaveCSV_Click(object sender, RoutedEventArgs e)
        {

            if (DGPersona.Items.Count > 1)
                gestionFile.GuardarCsv(DGPersona);
            else
                MessageBox.Show($"No puedes guardar una tabla vacia!!", "Aviso", MessageBoxButton.OK);

        }

        private void btnSaveDb_Click(object sender, RoutedEventArgs e)
        {
             if (DGPersona.Items.Count > 1)
                gestionDb.GuardaDGenDB(DGPersona);
            else
                MessageBox.Show($"No puedes exportar una tabla vacia!!", "Aviso", MessageBoxButton.OK);
 
        }

        private void DGPersona_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(DateTime))
                (e.Column as DataGridTextColumn).Binding.StringFormat = formatDate;
        }

        private void ActualizaNombreColumnasDGPersona(int cantidadColumnas)
        {
            if (cantidadColumnas > 0)
            {
                DGPersona.Columns[0].Header = "ID";
                DGPersona.Columns[1].Header = "Nombre";
                DGPersona.Columns[2].Header = "Apellidos";
                DGPersona.Columns[3].Header = "Edad";
                DGPersona.Columns[4].Header = "Rut";
                DGPersona.Columns[5].Header = "Digito Verificador";
                DGPersona.Columns[6].Header = "Fecha Nacimiento";
            }
        }
    }
}
