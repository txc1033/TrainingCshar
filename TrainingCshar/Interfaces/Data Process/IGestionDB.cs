using System.Collections.Generic;
using TrainingCshar.Models;

namespace TrainingCshar.Data_Process
{
    public interface IGestionDB
    {
        List<Persona> CargarEnDB();

        bool GuardarEnDB(List<Persona> personas);
    }
}