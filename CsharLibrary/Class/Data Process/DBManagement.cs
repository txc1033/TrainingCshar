using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CsharLibrary.Encoder;
using CsharLibrary.Models;


namespace CsharLibrary.Data_Process
{
    internal class DBManagement : IDBManagement
    {
        private IPerson person;
        private ISqlAccess sqlAccess;

        public DBManagement()
        {
            person = new Person();
            sqlAccess = new SqlAccess();
        }

        public List<Person> LoadDB()
        {
            return _Load();
        }

        public string SaveDB(List<Person> persons)
        {
            return _Save(persons);
        }

        private List<Person> _Load()
        {
            int seed = Environment.TickCount;
            Random random = new Random(seed);
            int range = random.Next(50, 500);

            var dtElements = sqlAccess.GetElementToDatabase(range);
            var people = person.DataTableToPeople(dtElements);

            return people;
        }

        private string _Save(List<Person> peopleGrid)
        {
            try
            {
                var peopleTable = person.PeopleToDataTable(peopleGrid);
                var result = sqlAccess.AddElementToDatabase(peopleTable); 

                return $"Se han agregado {result.FirstOrDefault().Key} de registros a la base de datos: {result.FirstOrDefault().Value}";
            }
            catch (Exception)
            {
                return $"El formato que se intenta exportar no es valido o esta vacio!";
            }
        }
    }
}