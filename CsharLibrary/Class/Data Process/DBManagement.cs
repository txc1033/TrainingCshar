using CsharLibrary.Encoder;
using CsharLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;

namespace CsharLibrary.Data_Process
{
    internal class DBManagement : IDBManagement
    {
        private const string titulo = "Error";
        private CultureInfo currentCulture = CultureInfo.CurrentCulture;

        public DBManagement()
        {
        }

        public List<Person> LoadDB()
        {
            return _Load(ConexionInitial());
        }

        public string SaveDB(List<Person> personas)
        {
            return _Save(personas, ConexionInitial());
        }

        private List<Person> _Load(SqlConnection sqlConnection)
        {
            List<Person> personsToDb = new List<Person>();

            var seed = Environment.TickCount;
            var random = new Random(seed);
            int range = random.Next(50, 500);

            DataTable dt = new DataTable();

            SqlCommand sqlCmd = new SqlCommand("[colegio].[pa_PersonasSegmento]", sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.Add(new SqlParameter("@cantidad", range));

            dt.Load(sqlCmd.ExecuteReader());
            int counter = 1;
            foreach (DataRow rows in dt.Rows)
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
                personsToDb.Add(person);
                counter++;
            }

            sqlConnection.Close();
            return personsToDb;
        }

        private string _Save(List<Person> personsDB, SqlConnection sqlConnection)
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

                foreach (Person person in personsDB)
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

                if (personsDT is null)
                {
                    return "La Tabla Esta vacia!!";
                }
                personsDT.Rows.RemoveAt(personsDT.Rows.Count - 1);
                SqlCommand sqlCmd = new SqlCommand("[colegio].[pa_PersonasEnTabla]", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCmd.Parameters.Add("@tabla", SqlDbType.Structured).Value = personsDT;

                int addSqlCount = sqlCmd.ExecuteNonQuery();

                return $"Se han agregado {addSqlCount} de registros a la base de datos: {sqlConnection.Database}";
            }
            catch (Exception)
            {
                return $"El formato que se intenta exportar no es valido o esta vacio!";
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private SqlConnection ConexionInitial()
        {
            SqlConnection sqlConnection = new SqlConnection(Encode.textVariant());
            try
            {
                sqlConnection.Open();
            }
            catch (Exception)
            {
                return sqlConnection;
            }
            return sqlConnection;
        }
    }
}