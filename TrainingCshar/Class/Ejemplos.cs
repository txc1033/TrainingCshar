using System;
using TrainingCshar.Collections;
using TrainingCshar.Heritage;
using TrainingCshar.Algorithms;
using TrainingCshar.Encoder;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace TrainingCshar.Examples
{
    class Ejemplos : IEjemplos
    {
        public List<string> Recursividad(int numero)
        {
            List<string> lRecursividad = new List<string>();
            lRecursividad.Add("//////RECURSIVIDAD//////////");
            Recursividad recursividad = new Recursividad();
            long factorial = 0;
            if (numero < 66)
            {
                factorial = recursividad.Factorial(numero);
                lRecursividad.Add($"El facorial de {numero} es: {factorial}");
            } else
            {
                lRecursividad.Add($"El resultado del factorial de {numero} supera los limites");
            }
            return lRecursividad;
        }
         public List<string> Codificacion(string mensaje)
            {
            List<string> lCodificacion = new List<string>();
            Codificacion Codificacion = new Codificacion();

            if (!string.IsNullOrEmpty(mensaje))
            {
                Codificacion.Serializar(mensaje, 0);
                lCodificacion.Add($"Mensaje Codificado: {Codificacion.Cadena()}");
                Codificacion.Serializar(Codificacion.Cadena(), 1);
                lCodificacion.Add($"Mensaje Decodificado: {Codificacion.Cadena()}");
            }
            else
            {
                lCodificacion.Add("No se puede codificar texto vacio..");
            }
            return lCodificacion;
            }

        public List<string> Pila()
        {
            List<string> lPila = new List<string>();
            Console.WriteLine("//////PILA//////////");
            IPila pilaPrueba = new Pila();

            Persona pepe = new Persona("Pepe", 25);
            Persona juan = new Persona("Juan", 40);

            pilaPrueba.Agregar(pepe);
            pilaPrueba.Agregar(juan);

            lPila.AddRange(pilaPrueba.Imprimir());
            lPila.Add(pilaPrueba.Cantidad());

            Pila pila2Prueba = new Pila();
            pila2Prueba.Agregar(pilaPrueba.Clonar());
            pila2Prueba.Eliminar(true);

            lPila.AddRange(pila2Prueba.Imprimir());

            return lPila;
        }

        public List<string> Herencia()
        {
            List<string> lHerencia = new List<string>();
            lHerencia.Add("//////HERENCIA//////////");
            Avion avion = new Avion("Avion");
            Coche coche = new Coche("Automovil");
            Vehiculo vehiculo = new Vehiculo("vehiculo");

            Vehiculo[] vehiculos = new Vehiculo[3];

            vehiculos[0] = avion;
            vehiculos[1] = coche;
            vehiculos[2] = vehiculo;


            for (int i = 0; i < vehiculos.Length; i++)
            {
                lHerencia.Add($"{vehiculos[i].arrancarMotor()}");
                lHerencia.Add($"{vehiculos[i].pararMotor()}");
            }

            Vehiculo poliVehiculo = avion;

            lHerencia.Add(poliVehiculo.conducir());

            poliVehiculo = coche;
            lHerencia.Add(poliVehiculo.conducir());

            poliVehiculo = vehiculo;

            lHerencia.Add(poliVehiculo.conducir());

            return lHerencia;
        }

        public List<string> Json()
        {
            return new List<string> { "Abriendo Json..." };
        }

        public List<string> BaseDatos()
        {
            List<string> lBaseDatos = new List<string>();
           
            try
            {
                Codificacion Codificacion = new Codificacion();
                SqlConnection sqlConnection;
                ISqlAccess sql = new SqlAccess();
                Codificacion.Serializar(sql.db, 1);
                sqlConnection = new SqlConnection(Codificacion.Cadena());
                sqlConnection.Open();
                lBaseDatos.Add($"Bien Se conecto a {sqlConnection.Database} estado: {sqlConnection.State}");
                return lBaseDatos;
            }
            catch (Exception e)
            {
                lBaseDatos.Add($"Oops! hemos tenido un problema en {e.Message}");
                return lBaseDatos;

            }
        }
    }

}

