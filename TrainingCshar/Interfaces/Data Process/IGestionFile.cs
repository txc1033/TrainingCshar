using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using TrainingCshar.Models;

namespace TrainingCshar.Data_Process
{
    interface IGestionFile
    {
        List<Persona> CargarEnCsv();
        bool GuardarEnCsv(List<Persona> personas);
    }
}