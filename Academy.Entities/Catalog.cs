using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Products;

namespace Entities.Catalogs
{
    public class Catalog
    {
        #region Constructor
        public Catalog(string catalogName, int catalogID) 
        {
            _catalogName = catalogName;
            _catalogID = catalogID;
        }

        public Catalog(string catalogName, int catalogID, Dictionary<Product, int> productQuantities)
        {
            _catalogName = catalogName;
            _catalogID = catalogID;
            _productsQuantity = productQuantities;
        }

        public Catalog(string catalogName, int catalogID, params Product[] products)
        {
            _catalogName = catalogName;
            _catalogID = catalogID;

            foreach (Product product in products)
            {
                product.SetReferenceCatalog(_catalogID);
                _productsQuantity.Add(product, 1);
            }
        }
        #endregion

        #region Private Variables
        private string _catalogName;
        private int _catalogID;
        private Dictionary<Product, int> _productsQuantity = new Dictionary<Product, int>();
        #endregion

        #region Public Variables
        #endregion

        #region Properties
        public string CatalogName => _catalogName; 
        public int CatalogID => _catalogID; 
        public Dictionary<Product, int> ProductsQuantity => _productsQuantity; 
        #endregion

        #region Private Methods
        private bool IsEnough(Product product, int amount)
        {
            return _productsQuantity[product] >= amount;
        }

        private bool IsEmpty(Product product)
        {
            return _productsQuantity[product] <= 0;
        }
        #endregion

        #region Public Methods
        public void AddProduct(Product product, int amount = 1)
        {
            if (product == null)
                return;

            if (_productsQuantity.ContainsKey(product))
            {
                _productsQuantity[product] += amount;

                if (IsEmpty(product))
                    RemoveProductFromCatalog(product);
            }
            else
            _productsQuantity.Add(product, amount);
        }

        public void SubtractProduct(Product product, int amount = 1)
        {
            if (product == null)
                return;

            if (_productsQuantity.ContainsKey(product))
            {
                if(IsEnough(product, amount))
                    _productsQuantity[product] -= amount;
            }
        }

        public void RemoveProductFromCatalog(Product product)
        {
            _productsQuantity.Remove(product);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Catalog Name: {_catalogName}; Catalog ID: {_catalogID};\n");

            foreach(KeyValuePair<Product,int> pair in _productsQuantity)
            {
                sb.AppendLine($"Product Name: {pair.Key.ProductName}; Amount: {pair.Value};");
            }

            return sb.ToString();
        }
        #endregion
    }
}
