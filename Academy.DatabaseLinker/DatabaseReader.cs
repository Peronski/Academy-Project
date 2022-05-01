using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DatabaseUtility.Reader
{
    public class DatabaseReader
    {
        #region Constructor
        #endregion

        #region Private Variables
        private static string CONNECTION_STRING;
        #endregion

        #region Public Variables
        #endregion

        #region Properties
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void ConfigureConnectionParameter(string dataSourceName, string dataBaseName, bool integratedSecurity, float connectionTimeOut)
        {
            CONNECTION_STRING = $"data source={dataSourceName};database={dataBaseName};Integrated Security={integratedSecurity};connection timeout={connectionTimeOut}";
        }

        public static Object GetInfoFromDatabase(string param)
        {
            using(SqlConnection connection = new SqlConnection(CONNECTION_STRING))
            {
                string query = @"SELECT [Attr.],
                                        [Attr.],
                                 FROM [Database].[dbo].[Attr.]
                                 WHERE [Attr] = @parametro ";

                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue(@"parametro", param);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // logic on single reading
                        //reader[Attr.] leggo valore per attributo risultato query

                        return null;
                    }
                }

                return null;
            }
        }
        #endregion
    }
}
