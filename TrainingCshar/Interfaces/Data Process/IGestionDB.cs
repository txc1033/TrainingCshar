using System.Collections.Generic;
using TrainingCshar.Models;

namespace TrainingCshar.Data_Process
{
    internal interface IGestionDB
    {
        List<Persona> CargarEnDB();

        bool GuardarEnDB(List<Persona> Personas);
    }
}