using System.Collections.Generic;
using CsharLibrary.Models;

namespace CsharLibrary.Data_Process
{
    public interface IFileManagement
    {
        List<Person> LoadCsv(string fileName);

        string SaveCsv(List<Person> personas,string path);

        string GetRootDirectory();

        string GetDefaultFileName();
    }
}