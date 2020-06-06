using System.Collections.Generic;
using CsharLibrary.Models;

namespace CsharLibrary.Data_Process
{
    public interface IDBManagement
    {
        List<Person> LoadDB();

        string SaveDB(List<Person> personas);
    }
}