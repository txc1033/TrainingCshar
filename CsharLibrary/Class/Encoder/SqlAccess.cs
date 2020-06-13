using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CsharLibrary.Encoder
{
    public sealed class SqlAccess : ISqlAccess
    {
        private readonly string sql_avanzado;
        private SqlConnection sqlConnection;
        public string db { get => sql_avanzado; }

        public SqlAccess()
        {
            sql_avanzado = "RABhAHQAYQAgAFMAbwB1AHIAYwBlAD0ASgBBAFYASQBEAEUAU";
            sql_avanzado += "wBLAFQATwBQADsASQBuAGkAdABpAGEAbAAgAEMAYQB0AGEAb";
            sql_avanzado += "ABvAGcAPQBzAHEAbABfAGEAdgBhAG4AegBhAGQAbwA7AFAAZ";
            sql_avanzado += "QByAHMAaQBzAHQAIABTAGUAYwB1AHIAaQB0AHkAIABJAG4AZ";
            sql_avanzado += "gBvAD0AVAByAHUAZQA7AFUAcwBlAHIAIABJAEQAPQBhAHAAc";
            sql_avanzado += "ABzADsAUABhAHMAcwB3AG8AcgBkAD0AYQBwAHMAMQAwADMAMQA=";
        }

        public DataTable GetElementToDatabase(int capacity)
        {
            return _GetElementToDatabase(capacity);
        }

        public Dictionary<int, string> AddElementToDatabase(DataTable table)
        {
            return _AddElementToDatabase(table);
        }

        private DataTable _GetElementToDatabase(int capacity)
        {
            DataTable dataTable = new DataTable();
            string procedure = "[colegio].[pa_PersonasSegmento]";
            SqlCommand sqlCmd = new SqlCommand(procedure, InitialConection());
            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Add(new SqlParameter("@cantidad", capacity));
            dataTable.Load(sqlCmd.ExecuteReader());
            FinishConection();
            return dataTable;
        }
        private Dictionary<int, string> _AddElementToDatabase(DataTable table)
        {
            if (table is null)
            {
                return null;
            }

            string procedure = "[colegio].[pa_PersonasEnTabla]";
            SqlCommand sqlCmd = new SqlCommand(procedure, InitialConection());

            sqlCmd.CommandType = CommandType.StoredProcedure;
            sqlCmd.Parameters.Add("@tabla", SqlDbType.Structured).Value = table;

            int addSqlCount = sqlCmd.ExecuteNonQuery();
            string databaseName = sqlConnection.Database;

            var result = new Dictionary<int, string>();
            result.Add(addSqlCount, databaseName);

            FinishConection();

            return result;
        }

        private SqlConnection InitialConection()
        {
            sqlConnection = new SqlConnection(Encode.textVariant());
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
        private void FinishConection()
        {
            if (sqlConnection.State == ConnectionState.Open)
            sqlConnection.Close();
        }


    }
}