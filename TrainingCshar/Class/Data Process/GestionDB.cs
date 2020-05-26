using System;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Windows;
using TrainingCshar.Models;
using System.Data;
using System.Windows.Controls;
using System.Globalization;
using TrainingCshar.Encoder;
using System.Collections.Generic;

namespace TrainingCshar.Data_Process
{
    public class GestionDB : IGestionDB
    {
        private const string titulo = "Error";
        private CultureInfo currentCulture = CultureInfo.CurrentCulture;

        public GestionDB()
        {
        }

        public List<Persona> CargarEnDB()
        {
            return _CargarEnDB(inicializaConexion());
        }
        public bool GuardarEnDB(List<Persona> personas)
        {
            return _GuardarEnDB(personas,inicializaConexion());
        }


        private List<Persona> _CargarEnDB(SqlConnection sqlConnection)
        {
            List<Persona> personasDb = new List<Persona>();

            var seed = Environment.TickCount;
            var random = new Random(seed);
            int rango = random.Next(50, 500);

            DataTable dt = new DataTable();

            SqlCommand sqlCmd = new SqlCommand("[colegio].[pa_PersonasSegmento]", sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            sqlCmd.Parameters.Add(new SqlParameter("@cantidad", rango));


            dt.Load(sqlCmd.ExecuteReader());
            int contador = 1;
            foreach (DataRow rows in dt.Rows)
            {
                Persona persona = new Persona()
                {
                    per_idPersona = contador,
                    per_nombre = rows[0].ToString(),
                    per_apellido = rows[1].ToString(),
                    per_edad = int.Parse(rows[2].ToString(), currentCulture),
                    per_rut = int.Parse(rows[3].ToString(), currentCulture),
                    per_dv = rows[4].ToString(),
                    per_fechaNacimiento = DateTime.Parse(rows[5].ToString(), currentCulture)
                };
                personasDb.Add(persona);
                contador++;
            }
            return personasDb;
        }
        private bool _GuardarEnDB(List<Persona> personas, SqlConnection sqlConnection)
        {
            try
            {
                DataTable dtPersona = new DataTable();
                dtPersona.Columns.Add("per_nombre", typeof(string));
                dtPersona.Columns.Add("per_apellido", typeof(string));
                dtPersona.Columns.Add("per_edad", typeof(int));
                dtPersona.Columns.Add("per_rut", typeof(int));
                dtPersona.Columns.Add("per_dv", typeof(char));
                dtPersona.Columns.Add("per_fechaNacimiento", typeof(DateTime));

                foreach (Persona persona in personas)
                {
                    var dataPersona = dtPersona.NewRow();
                    dataPersona[0] = persona.per_nombre;
                    dataPersona[1] = persona.per_apellido;
                    dataPersona[2] = persona.per_edad;
                    dataPersona[3] = persona.per_rut;
                    dataPersona[4] = persona.per_dv;
                    dataPersona[5] = persona.per_fechaNacimiento;
                    dtPersona.Rows.Add(dataPersona);
                }

                if (dtPersona is null)
                {
                    return false;
                }
                dtPersona.Rows.RemoveAt(dtPersona.Rows.Count - 1);
                SqlCommand sqlCmd = new SqlCommand("[colegio].[pa_PersonasEnTabla]", sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };

                sqlCmd.Parameters.Add("@tabla", SqlDbType.Structured).Value = dtPersona;

                int cantidadAgregadaSql = sqlCmd.ExecuteNonQuery();

                MessageBox.Show($"Se han agregado {cantidadAgregadaSql} de registros a la base de datos: {sqlConnection.Database}", titulo, MessageBoxButton.OK);
            }
            catch (Exception e)
            {
                MessageBox.Show($"El formato que se intenta exportar no es valido\n{e.TargetSite}", titulo, MessageBoxButton.OK);
                return false;
            }
            return true;
        }
        private SqlConnection inicializaConexion()
        {
            SqlConnection sqlConnection = new SqlConnection(Codificacion.Cadena());
            try
            {
                SqlAccess sql = new SqlAccess();
                Codificacion.Procesar(sql.db, false);
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
