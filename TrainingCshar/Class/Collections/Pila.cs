using System;
using System.Collections.Generic;

namespace TrainingCshar.Collections
{
    class Pila : IPila
    {
        private Stack<Persona> pilaPersona = new Stack<Persona>();

        public void Agregar(Persona persona)
        {
            pilaPersona.Push(persona);
        }

        public void Agregar(Stack<Persona> stack)
        {
            foreach (var persona in stack)
            {
                pilaPersona.Push(persona);
            }
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

        public string Cantidad()
        {
            return $"Cantidad de elementos en Pila: {pilaPersona.Count} ";
        }



        public List<string> Imprimir()
        {
            List<string> pl = new List<string>();
            foreach (var persona in pilaPersona)
            {
                pl.Add($"Hola Me llamo {persona.nombre} ");
                pl.Add($"y tengo {persona.edad} años ");
            }
            return pl;

        }

        public void Eliminar(bool todos)
        {
            if (todos) { pilaPersona.Clear(); } else { pilaPersona.Pop(); }
        }
    }

    public class Persona
    {
        private string _nombre;
        private int _edad;

        public Persona(string nombre,int edad = 15)
        {
            this._nombre = nombre;
            this._edad = edad;
        }

        public string nombre  { get => _nombre;}

        public int edad { get => _edad;}
    }


}
