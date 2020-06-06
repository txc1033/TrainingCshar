using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace CsharLibrary.Examples
{
    public class Orchestrator : IOrchestrator
    {
        private Examples example;
        private MethodInfo[] exampleMethods;

        public Orchestrator()
        {
            exampleMethods = typeof(Examples).GetMethods();
        }

        public List<string> ExecuteAction(string accion)
        {
            return _ExecuteAction(accion, exampleMethods);
        }

        public List<string> GetAcciones()
        {
            return _GetAcciones();
        }

        private List<string> _GetAcciones()
        {
            List<string> acciones = new List<string>();
            foreach (MethodInfo metodo in exampleMethods)
            {
                string excampleAction = metodo.Name;
                acciones.Add(excampleAction);
                foreach (MethodInfo metodoObject in typeof(object).GetMethods())
                {
                    if (excampleAction.Equals(metodoObject.Name, StringComparison.InvariantCultureIgnoreCase))
                    {
                        acciones.Remove(excampleAction);
                    }
                }
            }
            return acciones;
        }

        private List<string> _ExecuteAction(string action, MethodInfo[] exampleMethods)
        {
            try
            {
                example = new Examples();

                foreach (MethodInfo method in exampleMethods)
                {
                    ParameterInfo[] parameters = method.GetParameters();

                    if (method.Name == action)
                    {
                        List<string> answers;
                        if (parameters.Length < 1)
                        {
                            answers = (List<string>)Interaction.CallByName(example, action, CallType.Method);
                        }
                        else if (parameters[0].Name == "numero")
                        {
                            string mesage = $"Favor escribe un {parameters[0].Name} para la tarea {action}";
                            int value = int.Parse(Interaction.InputBox(mesage), CultureInfo.CurrentCulture);
                            answers = (List<string>)Interaction.CallByName(example, action, CallType.Method, value);
                        }
                        else
                        {
                            string mensaje = $"Favor escribe un {parameters[0].Name} para la tarea {action}";
                            string valor = Interaction.InputBox(mensaje);
                            answers = (List<string>)Interaction.CallByName(example, action, CallType.Method, valor);
                        }
                        return answers;
                    }
                }

                return new List<string> { $"Accion {action} No encontrada" };
            }
            catch (Exception e)
            {
                return new List<string> { $"Error en {action}: {e.Message}" };
            }
        }
    }
}