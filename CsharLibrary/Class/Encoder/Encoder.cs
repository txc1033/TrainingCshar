using System;
using System.Text;

namespace CsharLibrary.Encoder
{
    public class Encode
    {
        private static string _TextVariant;

        public static string textVariant()
        {
            return _TextVariant;
        }

        public static void Process(string text, bool isToEncode)
        {
            _ = isToEncode ? Encrypt(text) : Decrypt(text);
        }

        private static string Decrypt(string textToUncode)
        {
            byte[] decrypted = Convert.FromBase64String(textToUncode);
            _TextVariant = Encoding.Unicode.GetString(decrypted);
            return _TextVariant;
        }

        private static string Encrypt(string textToEncode)
        {
            byte[] encrypted = Encoding.Unicode.GetBytes(textToEncode);
            _TextVariant = Convert.ToBase64String(encrypted);
            return _TextVariant;
        }
    }
}