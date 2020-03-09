using System.Configuration;

namespace TrainingCshar.Encoder
{
    public sealed class SqlAccess : ISqlAccess
    {
        private readonly string sql_avanzado;
        public string db { get => sql_avanzado; }

        public SqlAccess()
        {
            sql_avanzado = ConfigurationManager.ConnectionStrings["sql_avanzado"].ToString();
        }
    }
}