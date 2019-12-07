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
            List<string> lRecursividadResult = new List<string>();
            lRecursividadResult.Add("//////RECURSIVIDAD//////////");
            Recursividad Recursivo = new Recursividad();
            long factorial = 0;
            if (numero < 66)
            {
                factorial = Recursivo.Factorial(numero);
                lRecursividadResult.Add($"El facorial de {numero} es: {factorial}");
            } else
            {
                lRecursividadResult.Add($"El resultado del factorial de {numero} supera los limites");
            }
            return lRecursividadResult;
        }
         public List<string> Codificacion(string mensaje)
            {
            List<string> lCodificacionResult = new List<string>();

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

        public List<string> Pila()
        {
            List<string> lPilaResult = new List<string>();
            Console.WriteLine("//////PILA//////////");
            IPila pilaPersona = new Pila();

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

        public List<string> Herencia()
        {
            List<string> lHerenciaResult = new List<string>();
            lHerenciaResult.Add("//////HERENCIA//////////");

            Vehiculo vehiculo = new Vehiculo("vehiculo");
            Avion avion = new Avion("Avion");
            Coche coche = new Coche("Automovil"); 

            Vehiculo[] vehiculos = new Vehiculo[3];

            vehiculos[0] = avion;
            vehiculos[1] = coche;
            vehiculos[2] = vehiculo;

            for (int i = 0; i < vehiculos.Length; i++)
            {
                lHerenciaResult.Add($"{vehiculos[i].arrancarMotor()}");
                lHerenciaResult.Add($"{vehiculos[i].pararMotor()}");
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

        public List<string> BaseDatos()
        {
            List<string> lBaseDatosResult = new List<string>();
           
            try
            {
                SqlConnection sqlConnection;
                ISqlAccess sql = new SqlAccess();
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
    }

}

