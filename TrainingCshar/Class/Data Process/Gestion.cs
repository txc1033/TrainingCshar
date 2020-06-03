using System.Collections.Generic;
using System.Threading.Tasks;
using TrainingCshar.Data_Process;
using TrainingCshar.Models;

namespace TrainingCshar.Class.Data_Process
{
    public class Gestion :  IGestion
    {
        private IGestionFile gestionFile;
        private IGestionDB gestionDb;
        private IGestionApi gestionApi;

        public Gestion()
        {
            gestionFile = new GestionFile();
            gestionDb = new GestionDB();
            gestionApi = new GestionApi();
        }

        public async Task<string> GetHttpUrl(string url)
        {
            return await gestionApi.GetHttpUrl(url);
        }

        public List<Persona> CargarEnCsv()
        {
            return gestionFile.CargarEnCsv();
        }

        public List<Persona> CargarEnDB()
        {
            return gestionDb.CargarEnDB();
        }

        public bool GuardarEnCsv(List<Persona> personas)
        {
            return gestionFile.GuardarEnCsv(personas);
        }

        public bool GuardarEnDB(List<Persona> personas)
        {
            return gestionDb.GuardarEnDB(personas);
        }
    }
}
