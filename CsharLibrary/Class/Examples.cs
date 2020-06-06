using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CsharLibrary.Algorithms;
using CsharLibrary.Encoder;

namespace CsharLibrary.Examples
{
    public class Examples
    {
        public List<string> BaseDatos()
        {
            List<string> lBaseDatosResult = new List<string>(3);

            try
            {
                SqlConnection sqlConnection;
                SqlAccess sql = new SqlAccess();
                Encoder.Encode.Process(sql.db, false);
                sqlConnection = new SqlConnection(Encoder.Encode.textVariant());
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
                Encoder.Encode.Process(mensaje, true);
                lCodificacionResult.Add($"Mensaje Codificado: {Encoder.Encode.textVariant()}");
                Encoder.Encode.Process(Encoder.Encode.textVariant(), false);
                lCodificacionResult.Add($"Mensaje Decodificado: {Encoder.Encode.textVariant()}");
            }
            else
            {
                lCodificacionResult.Add("No se puede codificar texto vacio..");
            }
            return lCodificacionResult;
        }

        public List<string> Json()
        {
            return new List<string> { "Abriendo Json..." };
        }

        public List<string> Recursividad(int numero)
        {
            List<string> lRecursividadResult = new List<string>(3)
            {
                "//////RECURSIVIDAD//////////"
            };
            Recursion recursividad = new Recursion();
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