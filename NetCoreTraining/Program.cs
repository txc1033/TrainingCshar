using System;

namespace NetCoreTraining
{
    class Program
    {
        static void Main(string[] args)
        {
            Object[] objetos = {"Perro", true, 12, 12.5, new Persona("Javier",25) };
            Console.WriteLine("Hello World!");
            RetornaObjetos(objetos);
            Console.ReadLine();
        }

        static private void RetornaObjetos(Object[] objetos)
        {
            foreach (var objeto in objetos)
            {
                Type tipo = objeto.GetType();

                if (tipo.Equals(typeof(Persona)))
                    Console.WriteLine($"{((Persona)objeto).Nombre}, {((Persona)objeto).Edad} es de tipo: {tipo}");
                else
                    Console.WriteLine($"{objeto} es de tipo: {tipo}");



            }
            
        }
    }

    class Persona
    {
        private string _nombre;
        private int _edad;
        public Persona(string nombre,int edad)
        {
            this.Nombre = nombre;
            this.Edad = edad;
        }

        public string Nombre { get => _nombre; set => _nombre = value; }
        public int Edad { get => _edad; set => _edad = value; }
    }
}
