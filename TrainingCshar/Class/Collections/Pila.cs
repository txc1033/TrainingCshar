using System.Collections.Generic;

namespace TrainingCshar.Collections
{
    public class PersonaPila
    {
        private readonly int _edad;
        private readonly string _nombre;

        public PersonaPila(string nombre, int edad = 15)
        {
            this._nombre = nombre;
            this._edad = edad;
        }

        public Stack<PersonaPila> ClonarPila(Stack<PersonaPila> personaPilas)
        {
            Pila pila = new Pila();

            foreach (var item in personaPilas)
            {
                pila.Agregar(item);
            }
            
            return pila.Clonar();
        }

        public int edad { get => _edad; }
        public string nombre { get => _nombre; }
    }

    internal class Pila : IPila
    {
        private readonly Stack<PersonaPila> pilaPersona = new Stack<PersonaPila>();

        public void Agregar(PersonaPila persona)
        {
            pilaPersona.Push(persona);
        }

        public void Agregar(Stack<PersonaPila> pilaPersonas)
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

        public Stack<PersonaPila> Clonar()
        {
            Stack<PersonaPila> pilaCopia = new Stack<PersonaPila>();

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