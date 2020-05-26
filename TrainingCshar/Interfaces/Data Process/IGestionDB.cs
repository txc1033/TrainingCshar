using System.Collections.Generic;
using System.Windows.Controls;
using TrainingCshar.Models;

namespace TrainingCshar.Data_Process
{
    interface IGestionDB
    {
        List<Persona> CargarEnDB();
        bool GuardarEnDB(List<Persona> Personas);
    }
}