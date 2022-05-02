using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Products;
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
        public static void ConfigureConnectionParameter(string dataSourceName, string dataBaseName, bool integratedSecurity, float connectionTimeOut)
        {
            CONNECTION_STRING = $"data source={dataSourceName};database={dataBaseName};Integrated Security={integratedSecurity};connection timeout={connectionTimeOut}";
        }

        public static string CreateConnectionString(string dataSourceName, string dataBaseName, bool integratedSecurity, float connectionTimeOut)
        {
            return CONNECTION_STRING = $"data source={dataSourceName};database={dataBaseName};Integrated Security={integratedSecurity};connection timeout={connectionTimeOut}";
        }

        public static List<Product> GetProductsFromDatabase(string connectionString)
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"SELECT [ProdottoID],
                                        [NomeProdotto],
                                        [CatalogoID],
                                        [Categoria],
                                        [Prezzo]
                                FROM [Cataloghi].[dbo].[Prodotto]";

                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Product product = new Product();

                        product.SetInfoProduct(int.Parse(reader[0].ToString()), reader[1].ToString(), int.Parse(reader[2].ToString()), reader[3].ToString(), float.Parse(reader[4].ToString()));

                        if(product != null)
                            products.Add(product);
                    }
                }

                return products;
            }
        }
        #endregion
    }
}
