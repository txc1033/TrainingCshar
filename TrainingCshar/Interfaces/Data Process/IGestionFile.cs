using System.Collections.Generic;
using TrainingCshar.Models;

namespace TrainingCshar.Data_Process
{
    public interface IGestionFile
    {
        List<Persona> CargarEnCsv();

        bool GuardarEnCsv(List<Persona> personas);
    }
}