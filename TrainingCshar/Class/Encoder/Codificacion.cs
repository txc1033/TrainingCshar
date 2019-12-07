using System;

namespace TrainingCshar.Encoder
{
    class Codificacion
    {
        private static string _cadena;

        public static string Cadena()
        {
            return _cadena;
        }


        public static void Serializar(string cadena, int accion = 0)
        {
            switch (accion)
            {
                case 0:
                    _cadena = Encriptar(cadena);
                    break;
                case 1:
                    _cadena = Desencriptar(cadena);
                    break;
                default:
                    _cadena = cadena;
                    break;
            }
        }


        private static string Encriptar(string cadena)
        {
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(cadena);
            _cadena = Convert.ToBase64String(encryted);
            return _cadena;
        }


        private static string Desencriptar(string cadena)
        {
            byte[] decryted = Convert.FromBase64String(cadena);
            _cadena = System.Text.Encoding.Unicode.GetString(decryted);
            return _cadena;
        }

    }
}
