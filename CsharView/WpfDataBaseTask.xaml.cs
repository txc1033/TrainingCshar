using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TrainingCshar.Class.Data_Process;
using TrainingCshar.Models;

namespace CsharView
{
    /// <summary>
    /// Lógica de interacción para WpfDataBaseTask.xaml
    /// </summary>
    public partial class WpfDataBaseTask : Window
    {
        private const string formatDate = "dd-MM-yyyy HH:mm:ss";
        private IGestion gestion;

        public WpfDataBaseTask()
        {
            InitializeComponent();
            InitializeDGPersona();
            gestion = new Gestion();
        }

        private void btnLoadCSV_Click(object sender, RoutedEventArgs e)
        {
            DGPersona.ItemsSource = gestion.CargarEnCsv();
            ActualizaNombreColumnasDGPersona(DGPersona.Columns.Count);
        }

        private void btnSaveCSV_Click(object sender, RoutedEventArgs e)
        {
                gestion.GuardarEnCsv(ConvertDataGridToList());
        }

        private void btnLoadDb_Click(object sender, RoutedEventArgs e)
        {
            DGPersona.ItemsSource = gestion.CargarEnDB();
            ActualizaNombreColumnasDGPersona(DGPersona.Columns.Count);
        }

        private void btnSaveDb_Click(object sender, RoutedEventArgs e)
        {
                gestion.GuardarEnDB(ConvertDataGridToList());
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

        private void InitializeDGPersona()
        {
            DGPersona.ItemsSource = new List<Persona>();
        }

        private List<Persona> ConvertDataGridToList()
        {
            if (DGPersona.Items.Count > 1)
            {
                return DGPersona.ItemsSource.Cast<Persona>().ToList();
            }
            else
            {
                return new List<Persona>();
            }
        }

    }
}