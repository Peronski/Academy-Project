using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Products
{
    public class Product
    {
        #region Constructor
        public Product() { }
        public Product(string productName, int productID)
        {
            _productName = productName; 
            _productID = productID; 
        }
        #endregion

        #region Private Variables
        private string _productName;
        private int _productID;
        private int _referenceCatalogID;
        private string _category;
        #endregion

        #region Public Variables
        #endregion

        #region Properties
        public string ProductName => _productName; 
        public int ProductID => _productID;
        public int CatalogID => _referenceCatalogID;
        public string Category => _category; 
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void SetInfoProduct(string productName, int productID, int catalogID, string category)
        {
            _productName = productName;
            _productID = productID;   
            _referenceCatalogID = catalogID;
            _category = category; ;
        }

        public void SetReferenceCatalog(int catalogID)
        {
            _referenceCatalogID = catalogID;
        }

        public override string ToString()
        {
            return $"Product Name: {_productName}; Product ID: {_productID}; Reference Catalog ID: {_referenceCatalogID}; Category: {Category}.";
        }
        #endregion
    }
}
