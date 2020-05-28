using System.Configuration;

namespace TrainingCshar.Encoder
{
    public sealed class SqlAccess : ISqlAccess
    {
        private readonly string sql_avanzado;
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
    }
}