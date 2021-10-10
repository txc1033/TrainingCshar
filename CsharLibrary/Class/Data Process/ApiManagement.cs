using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace CsharLibrary.Data_Process
{
    internal class ApiManagement : IApiManagement
    {
        private const string _pattern = @"^(http|https|ftp|)\://|[a-zA-Z0-9\-\.]+\.[a-zA-Z](:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;%\$#\=~])*[^\.\,\)\(\s]$";

        public string GetPattern()
        {
            return _pattern;
        }

        public async Task<string> GetHttpUrl(string url)
        {
            try
            {
                WebRequest webRequest = WebRequest.Create(url);
                WebResponse webResponse = webRequest.GetResponse();
                using (StreamReader sr = new StreamReader(webResponse.GetResponseStream()))
                {
                    return await sr.ReadToEndAsync();
                }
            }catch(Exception e)
            {
                return $"Error al procesar.. {e.Message}";
            }

        }
    }
}