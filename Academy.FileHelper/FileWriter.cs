using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Products;
using Entities.Catalogs;

namespace FileHelper.Writer
{
    public class FileWriter
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
        /// Writes product into a specific file.
        /// </summary>
        /// <param name="product">Product to be written.</param>
        /// <param name="dataPath">Location of file.</param>
        /// <param name="appendInFile">If it should be append.</param>
        public static void AddProduct(Product product, string dataPath, bool appendInFile)
        {
            //string infoProduct = $"ProductName: {product.ProductName}; ProductID: {product.ProductID}; ProductQuantity: {product.Quantity};";
            string infoProduct = $"{product.ProductName}; {product.ProductID}; {product.CatalogID};";

            using (StreamWriter streamWriter = new StreamWriter(dataPath, appendInFile))
            {
                streamWriter.WriteLine(infoProduct); 
            }
        }

        /// <summary>
        /// Writes catalog into a specific file.
        /// </summary>
        /// <param name="catalog">Catalog to be written.</param>
        /// <param name="dataPath">Location of file.</param>
        /// <param name="appendInFile">If it should be append.</param>
        public static void AddCatalog(Catalog catalog, string dataPath, bool appendInFile)
        {
            StringBuilder stringBuilder = new StringBuilder();

            //stringBuilder.Append($"CatalogName: {catalog.CatalogName}; CatalogID: {catalog.CatalogID}; ");
            stringBuilder.Append($"{catalog.CatalogName}; {catalog.CatalogID}; ");

            if (catalog.ProductsQuantity.Count <= 0)
            {
                //stringBuilder.Append("CatalogProducts: Empty;");
                stringBuilder.Append("Empty;");
            }
            else
            {
                //stringBuilder.Append("CatalogProducts: ");
                foreach (KeyValuePair<Product, int> pair in catalog.ProductsQuantity )
                {
                    stringBuilder.Append($"{pair.Key.ProductName}; {pair.Value};");
                }
            }

            using (StreamWriter streamWriter = new StreamWriter(dataPath, appendInFile))
            {
                streamWriter.WriteLine(stringBuilder.ToString());
            }
        }
        #endregion
    }
}
