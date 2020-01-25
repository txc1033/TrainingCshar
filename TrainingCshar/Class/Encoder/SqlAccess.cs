using System.Configuration;

namespace TrainingCshar.Encoder
{
    internal class SqlAccess : ISqlAccess
    {
        private string sql_avanzado;
        public string db { get => sql_avanzado; }

        public SqlAccess()
        {
            sql_avanzado = ConfigurationManager.ConnectionStrings["sql_avanzado"].ToString();
        }
    }
}