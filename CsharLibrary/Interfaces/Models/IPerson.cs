using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CsharLibrary.Models
{
    public interface IPerson
    {
        string per_apellido { get; set; }
        string per_dv { get; set; }
        int per_edad { get; set; }
        DateTime per_fechaNacimiento { get; set; }
        int per_idPersona { get; set; }
        string per_nombre { get; set; }
        int per_rut { get; set; }

        List<Person> DataTableToPeople(DataTable table);
        DataTable PeopleToDataTable(List<Person> people);
        StringBuilder PersonToText(List<Person> people);
        Person TextToPerson(string[] text);
    }
}