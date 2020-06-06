using CsharLibrary.Data_Process;
using CsharLibrary.Models;
using SimpleInjector;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CsharLibrary.Class.Data_Process
{
    public class Management : IManagement
    {
        private IFileManagement fileManagement;
        private IDBManagement dbManagement;
        private IApiManagement apiManagement;

        public Management(Container _container)
        {
            fileManagement = _container.GetInstance<IFileManagement>();
            dbManagement = _container.GetInstance<IDBManagement>();
            apiManagement = _container.GetInstance<IApiManagement>();
        }

        public async Task<string> GetHttpUrl(string url)
        {
            return await apiManagement.GetHttpUrl(url);
        }

        public string GetPattern()
        {
            return apiManagement.GetPattern();
        }

        public string GetFormatDate()
        {
            return fileManagement.GetFormatDate();
        }

        public string GetRootDirectory()
        {
            return fileManagement.GetRootDirectory();
        }

        public string GetDefaultFileName()
        {
            return fileManagement.GetDefaultFileName();
        }

        public List<Person> LoadCsv(string fileName)
        {
            return fileManagement.LoadCsv(fileName);
        }

        public List<Person> LoadDB()
        {
            return dbManagement.LoadDB();
        }

        public string SaveCsv(List<Person> personsDb, string fileName)
        {
            return fileManagement.SaveCsv(personsDb, fileName);
        }

        public string SaveDB(List<Person> personsDT)
        {
            return dbManagement.SaveDB(personsDT);
        }
    }
}