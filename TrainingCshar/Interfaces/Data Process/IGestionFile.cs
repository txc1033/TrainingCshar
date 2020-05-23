using System.Collections.ObjectModel;
using System.Windows.Controls;
using TrainingCshar.Models;

namespace TrainingCshar.Data_Process
{
    interface IGestionFile
    {
        ObservableCollection<Persona> CargarCsv();
        bool GuardarCsv(DataGrid dGPersona);
    }
}