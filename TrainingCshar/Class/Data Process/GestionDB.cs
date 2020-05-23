using System;
using System.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Windows;
using TrainingCshar.Models;
using System.Data;
using System.Windows.Controls;
using System.Globalization;
using TrainingCshar.Encoder;

namespace TrainingCshar.Data_Process
{
    public class GestionDB : IGestionDB
    {
        private const string titulo = "Error";
        private CultureInfo currentCulture = CultureInfo.CurrentCulture;

        public GestionDB()
        {
        }

        public ObservableCollection<Persona> CargarDB()
        {
            return _CargarDB(inicializaConexion());
        }

        public bool GuardaDGenDB(DataGrid dGPersona)
        {
            return _GuardaDGenDB(dGPersona, inicializaConexion());
        }

        private ObservableCollection<Persona> _CargarDB(SqlConnection sqlConnection)
        {
            ObservableCollection<Persona> personasDb = new ObservableCollection<Persona>();

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

        private bool _GuardaDGenDB(DataGrid dGPersona, SqlConnection sqlConnection)
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

                foreach (var item in dGPersona.Items)
                {
                    DataGridRow row = (DataGridRow)dGPersona.ItemContainerGenerator.ContainerFromItem(item);
                    if (row == null)
                        continue;
                    var fila = dtPersona.NewRow();
                    for (int j = 1; j < dGPersona.Columns.Count; j++)
                    {
                        FrameworkElement dato = dGPersona.Columns[j].GetCellContent(row);
                        string tipo = dtPersona.Columns[j - 1].DataType.Name.ToLower(currentCulture);
                        string datoText = ((TextBlock)dato).Text;
                        if (!string.IsNullOrEmpty(datoText))
                        {
                            switch (tipo)
                            {
                                case "int32":
                                    fila[j - 1] = Int32.Parse(datoText, currentCulture);
                                    break;
                                case "char":
                                    fila[j - 1] = Char.Parse(datoText);
                                    break;
                                case "datetime":
                                    fila[j - 1] = DateTime.Parse(datoText, currentCulture);
                                    break;

                                default:
                                    fila[j - 1] = datoText;
                                    break;
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(fila[0].ToString()))
                        dtPersona.Rows.Add(fila);
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
