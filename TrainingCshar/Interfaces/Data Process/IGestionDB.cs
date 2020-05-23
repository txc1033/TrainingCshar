using System.Collections.ObjectModel;
using System.Windows.Controls;
using TrainingCshar.Models;

namespace TrainingCshar.Data_Process
{
    interface IGestionDB
    {
        ObservableCollection<Persona> CargarDB();
        bool GuardaDGenDB(DataGrid dGPersona);
    }
}