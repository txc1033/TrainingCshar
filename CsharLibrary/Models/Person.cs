using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;

namespace CsharLibrary.Models
{
    public class Person : IPerson
    {
        public int per_idPersona { get; set; }
        public string per_nombre { get; set; }
        public string per_apellido { get; set; }
        public int per_edad { get; set; }
        public int per_rut { get; set; }
        public string per_dv { get; set; }
        public DateTime per_fechaNacimiento { get; set; }

        private CultureInfo currentCulture = CultureInfo.CurrentCulture;
        private int counter;

        public List<Person> DataTableToPeople(DataTable table)
        {
            return _DataTableToPerson(table);
        }

        public DataTable PeopleToDataTable(List<Person> people)
        {
            return _PersonToDataTable(people);
        }

        public StringBuilder PersonToText(List<Person> people)
        {
            return _PersonToText(people);
        }

        public Person TextToPerson(string[] text)
        {
            return _TextToPerson(text);
        }

        private List<Person> _DataTableToPerson(DataTable table)
        {
            List<Person> DbToPeople = new List<Person>();
            foreach (DataRow rows in table.Rows)
            {
                Person person = new Person()
                {
                    per_idPersona = counter,
                    per_nombre = rows[0].ToString(),
                    per_apellido = rows[1].ToString(),
                    per_edad = int.Parse(rows[2].ToString(), currentCulture),
                    per_rut = int.Parse(rows[3].ToString(), currentCulture),
                    per_dv = rows[4].ToString(),
                    per_fechaNacimiento = DateTime.Parse(rows[5].ToString(), currentCulture)
                };
                DbToPeople.Add(person);
                counter++;
            }

            return DbToPeople;
        }
        private DataTable _PersonToDataTable(List<Person> people)
        {
            try
            {
                DataTable personsDT = new DataTable();
                personsDT.Columns.Add("per_nombre", typeof(string));
                personsDT.Columns.Add("per_apellido", typeof(string));
                personsDT.Columns.Add("per_edad", typeof(int));
                personsDT.Columns.Add("per_rut", typeof(int));
                personsDT.Columns.Add("per_dv", typeof(char));
                personsDT.Columns.Add("per_fechaNacimiento", typeof(DateTime));

                foreach (Person person in people)
                {
                    var personData = personsDT.NewRow();
                    personData[0] = person.per_nombre;
                    personData[1] = person.per_apellido;
                    personData[2] = person.per_edad;
                    personData[3] = person.per_rut;
                    personData[4] = person.per_dv;
                    personData[5] = person.per_fechaNacimiento;
                    personsDT.Rows.Add(personData);
                }
                personsDT.Rows.RemoveAt(personsDT.Rows.Count - 1);
                return personsDT;
            }
            catch
            {
                return null;
            }


        }

        private Person _TextToPerson(string[] text)
        {
            bool textIsEqualsID = text[0].ToString(currentCulture).Equals("ID"
                                                   , StringComparison.CurrentCulture);

            bool textIsNotNull = string.IsNullOrEmpty(text[0].ToString(currentCulture));

            if (!textIsEqualsID && !textIsNotNull)
            {
                return new Person()
                {
                    per_idPersona = int.Parse(text[0], currentCulture),
                    per_nombre = text[1],
                    per_apellido = text[2],
                    per_edad = int.Parse(text[3], currentCulture),
                    per_rut = int.Parse(text[4], currentCulture),
                    per_dv = text[5],
                    per_fechaNacimiento = DateTime.Parse(text[6], currentCulture)
                };
            };
            return null;
        }

        private StringBuilder _PersonToText(List<Person> people)
        {
            StringBuilder text = new StringBuilder(2655, 28000);
            string columns = "ID,Nombre,Apellidos"
                           + ",Edad,Rut,Digito Verificador"
                           + ",Fecha Nacimiento";

            text.AppendLine(columns);
            int count = 1;
            foreach (var person in people)
            {
                string row = $"{count}"
                           + $",{person.per_nombre}"
                           + $",{person.per_apellido}"
                           + $",{person.per_edad}"
                           + $",{person.per_rut}"
                           + $",{person.per_dv}"
                           + $",{person.per_fechaNacimiento}";
                if (!string.IsNullOrEmpty(row))
                    text.AppendLine(row);

                count++;
            }

            return text;
        }


    }
}