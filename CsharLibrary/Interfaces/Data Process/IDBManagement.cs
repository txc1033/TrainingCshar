using CsharLibrary.Models;
using System.Collections.Generic;

namespace CsharLibrary.Data_Process
{
    public interface IDBManagement
    {
        List<Person> LoadDB();

        string SaveDB(List<Person> personas);
    }
}