using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Products;
using Entities.Catalogs;
using System.IO;

namespace FileHelper.Reader
{
    public class FileReader
    {
        #region Constructor
        #endregion

        #region Private Variables
        #endregion

        #region Public Variables
        #endregion

        #region Properties
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        /// <summary>
        /// Reads all products' infos and returns a list of all products created using those infos.
        /// </summary>
        /// <param name="dataPath">Location of file</param>
        /// <returns>List of all products constructed from infos.</returns>
        public static List<Product> ReadProducts(string dataPath)
        {
            List<Product> products = new List<Product>();

            using (StreamReader streamReader = new StreamReader(dataPath))
            {
                while (!streamReader.EndOfStream)
                {
                    string row = streamReader.ReadLine();

                    string[] infoSingleProduct = row.Split(";"); // se non ho idea di quante informazioni otterro'?

                    Product product = new Product();

                    product.SetInfoProduct(int.Parse(infoSingleProduct[0]), infoSingleProduct[1], int.Parse(infoSingleProduct[2]), infoSingleProduct[3], int.Parse(infoSingleProduct[4]));

                    products.Add(product);
                }
                return products;
            }
        }

        /// <summary>
        /// Obtains all infos relative to a product from a file and uses them to create relative product.
        /// </summary>
        /// <param name="dataPath">Location of file.</param>
        /// <param name="nameProduct">Product's name.</param>
        /// <returns>The product created reading those file's infos.</returns>
        public static Product GetProductInfoFromFileByName(string dataPath, string nameProduct)
        {
            Product product = new Product();

            using (StreamReader streamReader = new StreamReader(dataPath))
            {
                while (!streamReader.EndOfStream)
                {
                    string row = streamReader.ReadLine();

                    string[] infoSingleProduct = row.Split(";"); // se non ho idea di quante informazioni otterro'?

                    if (infoSingleProduct[1].Trim().Equals(nameProduct))
                    {
                        product.SetInfoProduct(int.Parse(infoSingleProduct[0]), infoSingleProduct[1], int.Parse(infoSingleProduct[2]), infoSingleProduct[3], int.Parse(infoSingleProduct[4]));

                        return product;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Reads all catalogs' infos and returns a list of all catalogs created using those infos.
        /// Reads and creates also products using infos contained into catalogs.
        /// </summary>
        /// <param name="catalogsDataPath">Location of file</param>
        /// <returns>List of all products constructed from infos.</returns>
        public static List<Catalog> ReadCatalogs(string catalogsDataPath, string productsDataPath)
        {
            List<Catalog> catalogs = new List<Catalog>();

            using (StreamReader streamReader = new StreamReader(catalogsDataPath))
            {
                while (!streamReader.EndOfStream)
                {
                    string row = streamReader.ReadLine();

                    string[] infoSingleCatalog = row.Split(";"); // se non ho idea di quante informazioni otterro'?

                    Catalog catalog = new Catalog(infoSingleCatalog[0], int.Parse(infoSingleCatalog[1]), infoSingleCatalog[2]);

                    if (infoSingleCatalog[3].Equals("Empty;"))
                    {
                        catalogs.Add(catalog);
                    }
                    else
                    {
                        for (int i = 3; i < infoSingleCatalog.Length - 1; i++ )
                        {
                            string productName = infoSingleCatalog[i].Trim();
                            int quantity = int.Parse(infoSingleCatalog[i + 1].Trim());
                            Product product = GetProductInfoFromFileByName(productsDataPath, productName);

                            if(product != null)
                                catalog.AddProduct(product, quantity);

                            i++; //TODO: fa schifo
                        }
                        catalogs.Add(catalog);
                    }
                }
                return catalogs;
            }
        }
        #endregion
    }
}
