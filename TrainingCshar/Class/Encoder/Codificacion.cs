namespace TrainingCshar.Encoder
{
    class Codificacion
    {
        private static string _cadena;
        public static string Cadena()
        {
            return _cadena;
        }

        public static void Procesar(string cadena, bool codifica)
        {
            cadena = codifica ? Encriptar(cadena) : Desencriptar(cadena);
        }

        private static string Encriptar(string cadena)
        {
            byte[] encriptado = System.Text.Encoding.Unicode.GetBytes(cadena);
            _cadena = System.Convert.ToBase64String(encriptado);
            return _cadena;
        }

        private static string Desencriptar(string cadena)
        {
            byte[] desencriptado = System.Convert.FromBase64String(cadena);
            _cadena = System.Text.Encoding.Unicode.GetString(desencriptado);
            return _cadena;
        }

    }
}
