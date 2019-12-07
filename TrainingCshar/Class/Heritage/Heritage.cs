using System;

namespace TrainingCshar.Heritage
{
    public class Vehiculo
    {
        private string vehiculo;

        public string arrancarMotor()
        {
            return $"Estoy arracando el motor del {vehiculo}";
        }

        public string pararMotor()
        {
            return $"Estoy deteniendo el motor del {vehiculo}";
        }

        public virtual string conducir()
        {
            return $"Estoy manejando el {vehiculo}";
        }

        public Vehiculo(string nombre)
        {
            vehiculo = nombre;
        }
    }

    public class Coche : Vehiculo
    {
        public Coche(string nombre) : base(nombre)
        {

        }

        new public virtual string conducir()
        {
            return "Estoy avanzando por la carretera";
        }
    }

    public class Avion : Vehiculo
    {
        public Avion(string nombre) : base(nombre)
        {

        }

        public override string conducir()
        {
            return "Estoy volando por los aires";
        }
    }
}
