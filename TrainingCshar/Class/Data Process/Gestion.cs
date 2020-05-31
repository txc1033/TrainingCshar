using System.Collections.Generic;
using TrainingCshar.Data_Process;
using TrainingCshar.Models;

namespace TrainingCshar.Class.Data_Process
{
    public class Gestion : IGestionDB, IGestionFile, IGestion
    {
        private IGestionFile gestionFile;
        private IGestionDB gestionDb;

        public Gestion()
        {
            gestionFile = new GestionFile();
            gestionDb = new GestionDB();
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
