using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using TrainingCshar.Algorithms;
using TrainingCshar.Collections;
using TrainingCshar.Encoder;
using TrainingCshar.Heritage;

namespace TrainingCshar.Examples
{
    internal sealed class Ejemplos : IEjemplos
    {
        public List<string> BaseDatos()
        {
            List<string> lBaseDatosResult = new List<string>(3);

            try
            {
                SqlConnection sqlConnection;
                SqlAccess sql = new SqlAccess();
                Encoder.Codificacion.Procesar(sql.db, false);
                sqlConnection = new SqlConnection(Encoder.Codificacion.Cadena());
                sqlConnection.Open();
                lBaseDatosResult.Add($"Bien Se conecto a {sqlConnection.Database} estado: {sqlConnection.State}");
                return lBaseDatosResult;
            }
            catch (Exception e)
            {
                lBaseDatosResult.Add($"Oops! hemos tenido un problema en {e.Message}");
                return lBaseDatosResult;
            }
        }

        public List<string> Codificacion(string mensaje)
        {
            List<string> lCodificacionResult = new List<string>(3);

            if (!string.IsNullOrEmpty(mensaje))
            {
                Encoder.Codificacion.Procesar(mensaje, true);
                lCodificacionResult.Add($"Mensaje Codificado: {Encoder.Codificacion.Cadena()}");
                Encoder.Codificacion.Procesar(Encoder.Codificacion.Cadena(), false);
                lCodificacionResult.Add($"Mensaje Decodificado: {Encoder.Codificacion.Cadena()}");
            }
            else
            {
                lCodificacionResult.Add("No se puede codificar texto vacio..");
            }
            return lCodificacionResult;
        }

        public List<string> Herencia()
        {
            List<string> lHerenciaResult = new List<string>(3)
            {
                "//////HERENCIA//////////"
            };

            Vehiculo vehiculo = new Vehiculo("vehiculo");
            Avion avion = new Avion("Avion");
            Coche coche = new Coche("Automovil");

            Vehiculo[] vehiculos = new Vehiculo[3];

            vehiculos[0] = avion;
            vehiculos[1] = coche;
            vehiculos[2] = vehiculo;

            foreach (Vehiculo _vehiculo in vehiculos)
            {
                lHerenciaResult.Add($"{_vehiculo.arrancarMotor()}");
                lHerenciaResult.Add($"{_vehiculo.pararMotor()}");
            }

            Vehiculo poliMorphVehiculo = avion;

            lHerenciaResult.Add(poliMorphVehiculo.conducir());

            poliMorphVehiculo = coche;
            lHerenciaResult.Add(poliMorphVehiculo.conducir());

            poliMorphVehiculo = vehiculo;

            lHerenciaResult.Add(poliMorphVehiculo.conducir());

            return lHerenciaResult;
        }

        public List<string> Json()
        {
            return new List<string> { "Abriendo Json..." };
        }

        public List<string> Pila()
        {
            List<string> lPilaResult = new List<string>(3);
            Console.WriteLine("//////PILA//////////");
            Pila pilaPersona = new Pila();

            Persona pepe = new Persona("Pepe", 25);
            Persona juan = new Persona("Juan", 40);

            pilaPersona.Agregar(pepe);
            pilaPersona.Agregar(juan);

            lPilaResult.AddRange(pilaPersona.Imprimir());
            lPilaResult.Add(pilaPersona.Cantidad());

            Pila pilaClon = new Pila();
            pilaClon.Agregar(pilaPersona.Clonar());
            pilaClon.Eliminar(true);

            lPilaResult.AddRange(pilaClon.Imprimir());

            return lPilaResult;
        }

        public List<string> Recursividad(int numero)
        {
            List<string> lRecursividadResult = new List<string>(3)
            {
                "//////RECURSIVIDAD//////////"
            };
            Recursividad recursividad = new Recursividad();
            if (numero < 66)
            {
                long factorial = recursividad.Factorial(numero);
                lRecursividadResult.Add($"El facorial de {numero} es: {factorial}");
            }
            else
            {
                lRecursividadResult.Add($"El resultado del factorial de {numero} supera los limites");
            }
            return lRecursividadResult;
        }
    }
}