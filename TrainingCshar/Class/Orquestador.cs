using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace TrainingCshar.Examples
{
    public class Orquestador
    {
        private Ejemplos ejemplos;
        private MethodInfo[] metodosEjemplos;

        public Orquestador()
        {
            metodosEjemplos = typeof(Ejemplos).GetMethods();
        }

        public List<string> EjecutaAccion(string accion)
        {
            return _EjecutaAccion(accion, metodosEjemplos);
        }

        public List<string> GetAcciones()
        {
            return _GetAcciones();
        }

        private List<string> _GetAcciones()
        {
            List<string> acciones = new List<string>();
            foreach (MethodInfo metodo in metodosEjemplos)
            {
                string accionEjemplo = metodo.Name;
                acciones.Add(accionEjemplo);
                foreach (MethodInfo metodoObject in typeof(object).GetMethods())
                {
                    if (accionEjemplo.Equals(metodoObject.Name, StringComparison.InvariantCultureIgnoreCase))
                    {
                        acciones.Remove(accionEjemplo);
                    }
                }
            }
            return acciones;
        }

        private List<string> _EjecutaAccion(string accion, MethodInfo[] metodosEjemplos)
        {
            try
            {
                ejemplos = new Ejemplos();

                foreach (MethodInfo metodo in metodosEjemplos)
                {
                    ParameterInfo[] parametros = metodo.GetParameters();

                    if (metodo.Name == accion)
                    {
                        List<string> respuestas;
                        if (parametros.Length < 1)
                        {
                            respuestas = (List<string>)Interaction.CallByName(ejemplos, accion, CallType.Method);
                        }
                        else if (parametros[0].Name == "numero")
                        {
                            string mensaje = $"Favor escribe un {parametros[0].Name} para la tarea {accion}";
                            int valor = int.Parse(Interaction.InputBox(mensaje), CultureInfo.CurrentCulture);
                            respuestas = (List<string>)Interaction.CallByName(ejemplos, accion, CallType.Method, valor);
                        }
                        else
                        {
                            string mensaje = $"Favor escribe un {parametros[0].Name} para la tarea {accion}";
                            string valor = Interaction.InputBox(mensaje);
                            respuestas = (List<string>)Interaction.CallByName(ejemplos, accion, CallType.Method, valor);
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
    }
}