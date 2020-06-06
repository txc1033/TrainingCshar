using CsharLibrary.Class.Data_Process;
using CsharLibrary.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CsharView
{
    /// <summary>
    /// Lógica de interacción para WpfDataBaseTask.xaml
    /// </summary>
    public partial class WpfDataBaseTask : Window
    {
        private string estadoMesanje = "La tabla esta vacia";
        private IManagement management;
        public WpfDataBaseTask(IManagement _management)
        {
            InitializeComponent();
            InitializeDGPersona();
            management = _management;
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

        private void btnLoadCSV_Click(object sender, RoutedEventArgs e)
        {
            string pathToLoad = ObtainPathToAction(false);
            DGPersona.ItemsSource = management.LoadCsv(pathToLoad);
            ActualizaNombreColumnasDGPersona(DGPersona.Columns.Count);
        }

        private void btnLoadDb_Click(object sender, RoutedEventArgs e)
        {
            DGPersona.ItemsSource = management.LoadDB();
            ActualizaNombreColumnasDGPersona(DGPersona.Columns.Count);
        }

        private void btnSaveCSV_Click(object sender, RoutedEventArgs e)
        {
            string pathToSave = ObtainPathToAction(true);
            estadoMesanje = management.SaveCsv(ConvertDataGridToList(), pathToSave);
            callMessage(estadoMesanje);
        }
        private void btnSaveDb_Click(object sender, RoutedEventArgs e)
        {
            estadoMesanje = management.SaveDB(ConvertDataGridToList());
            callMessage(estadoMesanje);
        }

        private void callMessage(string message)
        {
            if (!string.IsNullOrEmpty(message))
                MessageBox.Show(message, "Mensaje", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private List<Person> ConvertDataGridToList()
        {
            if (DGPersona.Items.Count > 1)
            {
                return DGPersona.ItemsSource.Cast<Person>().ToList();
            }
            else
            {
                return new List<Person>();
            }
        }

        private void DGPersona_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs _event)
        {
            if (_event.PropertyType == typeof(DateTime))
                (_event.Column as DataGridTextColumn).Binding.StringFormat = management.GetFormatDate();
        }
        private void InitializeDGPersona()
        {
            DGPersona.ItemsSource = new List<Person>();
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
                bool? result = saveFileDialog.ShowDialog();
                if (result == true)
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
                bool? result = openFileDialog.ShowDialog();
                if (result == true)
                    path = openFileDialog.FileName;
            }
            return path;
        }
    }
}