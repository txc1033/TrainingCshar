using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualBasic;
using System.Windows.Forms;

namespace TrainingCshar.Formulaio
{
    public partial class FStart : Form
    {
        Type tiposEjemplo;

        //public List<string> resultados = new List<string>();

        public FStart()
        { 
            InitializeComponent();
            tiposEjemplo = typeof(Examples.Ejemplos);
            MethodInfo[] metodosEjemplos = tiposEjemplo.GetMethods();
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
                    if (accion.Equals(metodoObject.Name))
                    {
                        cmbAcciones.Items.Remove(accion);
                    }
                }

            }
        }

        private void CmbAcciones_TextChanged(object sender, EventArgs e)
        {
            int posicionAccion = cmbAcciones.FindString(cmbAcciones.Text.ToString());
            int indiceAcciones = posicionAccion > 0 ? posicionAccion : 0;
            cmbAcciones.SelectedIndex = indiceAcciones ;
            btnEjecutar.Text = indiceAcciones > 0 ? $"Ejecutar: {cmbAcciones.Text}": "Ejecutar: Nada";
        }
        private void BtnEjecutar_Click(object sender, EventArgs e)
        {
            txtResultado.Clear();
            string accion = cmbAcciones.Text;
            List<string> resultados =  EjecutaAccion(accion);
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
                    if (txtResultado.Text.ToLower().Contains("open"))
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
                Examples.Ejemplos clsEjemplos = new Examples.Ejemplos();
                MethodInfo[] mEjemplos = tiposEjemplo.GetMethods();
                
                foreach (MethodInfo ejemplo in mEjemplos)
                {
                    ParameterInfo[] parametros = ejemplo.GetParameters();
                    
                    if (ejemplo.Name == accion)
                    { 
                        dynamic respuesta;
                      if (parametros.Length < 1)
                        {
                            respuesta = Interaction.CallByName(clsEjemplos, ejemplo.Name, CallType.Method);
                        }else if(parametros[0].Name == "numero")
                        {
                            string mensaje = $"Favor escribe un {parametros[0].Name} para la tarea {ejemplo.Name}";
                            string valor = Interaction.InputBox(mensaje);
                            respuesta = Interaction.CallByName(clsEjemplos, ejemplo.Name, CallType.Method, int.Parse(valor));
                        }
                        else
                        {
                            string mensaje = $"Favor escribe un {parametros[0].Name} para la tarea {ejemplo.Name}";
                            string valor = Interaction.InputBox(mensaje);
                            respuesta = Interaction.CallByName(clsEjemplos, ejemplo.Name, CallType.Method, valor);
                        }
                        return new List<string> { respuesta};
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
            FApiTask fApi = new FApiTask();
            this.Hide();
            fApi.ShowDialog();
            this.Show();
        }

        private void OpenFDb()
        {
            FDataBaseTask fDB = new FDataBaseTask();
            this.Hide();
            fDB.ShowDialog();
            this.Show();
        }

        private void CmbAccion_Click(object sender, EventArgs e)
        {
            cmbAcciones.SelectAll();
        }

        private void CmbAccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEjecutar.Enabled = cmbAcciones.SelectedIndex > 0 ? true : false;
        }

        private void CmbAccion_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            cmbAcciones.SelectAll();
        }
    }
}
