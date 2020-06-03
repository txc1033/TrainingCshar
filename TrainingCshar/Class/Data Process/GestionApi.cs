using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace TrainingCshar.Data_Process
{
    class GestionApi : IGestionApi
    {
        public async Task<string> GetHttpUrl(string url)
        {
            WebRequest webRequest = WebRequest.Create(url);
            WebResponse webResponse = webRequest.GetResponse();
            using (StreamReader sr = new StreamReader(webResponse.GetResponseStream()))
            {
                return await sr.ReadToEndAsync();
            }
        }
    }
}
