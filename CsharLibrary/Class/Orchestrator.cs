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
        private string mesage;

        public Orchestrator()
        {
            exampleMethods = typeof(Examples).GetMethods();
        }

        public List<string> ExecuteAction(string action)
        {
            return _ExecuteAction(action, exampleMethods);
        }

        public List<string> GetActions()
        {
            return _GetActions();
        }

        private List<string> _GetActions()
        {
            List<string> actions = new List<string>();
            foreach (MethodInfo method in exampleMethods)
            {
                string exampleAction = method.Name;
                actions.Add(exampleAction);
                foreach (MethodInfo metodoObject in typeof(object).GetMethods())
                {
                    if (exampleAction.Equals(metodoObject.Name, StringComparison.InvariantCultureIgnoreCase))
                    {
                        actions.Remove(exampleAction);
                    }
                }
            }
            return actions;
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
                            mesage = $"Favor escribe un {parameters[0].Name} para la tarea {action}";
                            int value = int.Parse(Interaction.InputBox(mesage), CultureInfo.CurrentCulture);
                            answers = (List<string>)Interaction.CallByName(example, action, CallType.Method, value);
                        }
                        else
                        {
                            mesage = $"Favor escribe un {parameters[0].Name} para la tarea {action}";
                            string valor = Interaction.InputBox(mesage);
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