using CsharLibrary.Algorithms;
using CsharLibrary.Encoder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CsharLibrary.Examples
{
    public class Examples
    {
        private const int limite = 66;
        private string mensajeCodificado, mensajeDecodificado;
        private List<string> lMessageResult;

        public Examples()
        {
            lMessageResult =  new List<string>(3);
        }

        public List<string> BaseDatos()
        {
            lMessageResult.Clear();

            try
            {
                SqlConnection sqlConnection;
                SqlAccess sql = new SqlAccess();
                Encoder.Encode.Process(sql.db, false);
                mensajeDecodificado = Encoder.Encode.textVariant();
                sqlConnection = new SqlConnection(mensajeDecodificado);
                sqlConnection.Open();
                lMessageResult.Add($"Bien Se conecto a {sqlConnection.Database} estado: {sqlConnection.State}");
                return lMessageResult;
            }
            catch (Exception e)
            {
                lMessageResult.Add($"Oops! hemos tenido un problema en {e.Message}");
                return lMessageResult;
            }
        }

        public List<string> Codificacion(string mensaje)
        {
            
            lMessageResult.Clear();

            if (!string.IsNullOrEmpty(mensaje))
            {
                Encoder.Encode.Process(mensaje, true);
                mensajeCodificado = Encoder.Encode.textVariant();
                lMessageResult.Add($"Mensaje Codificado: {mensajeCodificado}");
                Encoder.Encode.Process(mensajeCodificado, false);
                mensajeDecodificado = Encoder.Encode.textVariant();
                lMessageResult.Add($"Mensaje Decodificado: {mensajeDecodificado}");
            }
            else
            {
                lMessageResult.Add("No se puede codificar texto vacio..");
            }
            return lMessageResult;
        }

        public List<string> Json()
        {
            lMessageResult.Clear();

            lMessageResult.Add("Abriendo Json...");

            return lMessageResult;
        }

        public List<string> Recursividad(int numero)
        {
            lMessageResult.Clear();

            lMessageResult.Add("//////RECURSIVIDAD//////////");
            
            IRecursion recursividad = new Recursion();
            if (numero < limite)
            {
                lMessageResult.Add($"El facorial de {numero} es: {recursividad.Factorial(numero)}");
            }
            else
            {
                lMessageResult.Add($"El resultado del factorial de {numero} supera los limites");
            }
            return lMessageResult;
        }
    }
}