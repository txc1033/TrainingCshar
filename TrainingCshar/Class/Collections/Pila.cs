using System.Collections.Generic;

namespace TrainingCshar.Collections
{
    public class Persona
    {
        private int _edad;
        private string _nombre;

        public Persona(string nombre, int edad = 15)
        {
            this._nombre = nombre;
            this._edad = edad;
        }

        public int edad { get => _edad; }
        public string nombre { get => _nombre; }
    }

    internal class Pila : IPila
    {
        private Stack<Persona> pilaPersona = new Stack<Persona>();

        public void Agregar(Persona persona)
        {
            pilaPersona.Push(persona);
        }

        public void Agregar(Stack<Persona> pilaPersonas)
        {
            foreach (var persona in pilaPersonas)
            {
                pilaPersona.Push(persona);
            }
        }

        public string Cantidad()
        {
            return $"Cantidad de elementos en Pila: {pilaPersona.Count} ";
        }

        public Stack<Persona> Clonar()
        {
            Stack<Persona> pilaCopia = new Stack<Persona>();

            foreach (var persona in pilaPersona)
            {
                pilaCopia.Push(persona);
            }

            return pilaCopia;
        }

        public void Eliminar(bool todos)
        {
            if (todos) { pilaPersona.Clear(); } else { pilaPersona.Pop(); }
        }

        public List<string> Imprimir()
        {
            List<string> strPila = new List<string>();
            foreach (var persona in pilaPersona)
            {
                strPila.Add($"Hola Me llamo {persona.nombre} ");
                strPila.Add($"y tengo {persona.edad} años ");
            }
            return strPila;
        }
    }
}