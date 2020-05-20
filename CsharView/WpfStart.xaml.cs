using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using TrainingCshar.Examples;
using TrainingCshar.Formulaio;
using System.Globalization;

namespace CsharView
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MethodInfo[] metodosEjemplos;
        public MainWindow()
        {
            InitializeComponent();
            metodosEjemplos = typeof(Ejemplos).GetMethods();
            InitializeCombobox(metodosEjemplos);
        }

        private void InitializeCombobox(MethodInfo[] listaMetodos)
        {
            cmbAcciones.Items.Add("Seleccione Una Accion...");
            cmbAcciones.SelectedIndex = 0;

            Type tipoObject = typeof(object);

            MethodInfo[] metodosObject = tipoObject.GetMethods();

            foreach (MethodInfo metodo in listaMetodos)
            {
                string accion = metodo.Name;
                cmbAcciones.Items.Add(accion);
                foreach (MethodInfo metodoObject in metodosObject)
                {
                    if (accion.Equals(metodoObject.Name, StringComparison.InvariantCultureIgnoreCase))
                    {
                        cmbAcciones.Items.Remove(accion);
                    }
                }
            }
        }

        private void BtnEjecutarClick(object sender, RoutedEventArgs e)
        {
            txtResultado.Clear();
            string accion = cmbAcciones.Text;
            List<string> resultados = EjecutaAccion(accion);
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

        private List<string> EjecutaAccion(string accion)
        {
            try
            {
                Ejemplos Ejemplos = new Ejemplos();

                foreach (MethodInfo metodo in metodosEjemplos)
                {
                    ParameterInfo[] parametros = metodo.GetParameters();

                    if (metodo.Name == accion)
                    {
                        List<string> respuestas;
                        if (parametros.Length < 1)
                        {
                            respuestas = (List<string>)Interaction.CallByName(Ejemplos, accion, CallType.Method);
                        }
                        else if (parametros[0].Name == "numero")
                        {
                            string mensaje = $"Favor escribe un {parametros[0].Name} para la tarea {accion}";
                            int valor = int.Parse(Interaction.InputBox(mensaje), CultureInfo.CurrentCulture);
                            respuestas = (List<string>)Interaction.CallByName(Ejemplos, accion, CallType.Method, valor);
                        }
                        else
                        {
                            string mensaje = $"Favor escribe un {parametros[0].Name} para la tarea {accion}";
                            string valor = Interaction.InputBox(mensaje);
                            respuestas = (List<string>)Interaction.CallByName(Ejemplos, accion, CallType.Method, valor);
                        }
                        return respuestas;
                    }
                }

                return new List<string> { $"Accion {accion} No encontrada" };
            }
            catch (Exception e)
            {
                return new List<string> { $"Error en {accion}: {e.Message}" };
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
