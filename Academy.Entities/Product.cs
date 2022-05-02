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

        public Product(int productID, string productName, string category, float price)
        {
            _productName = productName;
            _productID = productID;
            _category = category;
            _productPrice = price;
        }
        #endregion

        #region Private Variables
        private int _productID;
        private string _productName;
        private int _referenceCatalogID;
        private string _category;
        private float _productPrice;
        #endregion

        #region Public Variables
        #endregion

        #region Properties
        public int ProductID => _productID;
        public string ProductName => _productName; 
        public int CatalogID => _referenceCatalogID;
        public string Category => _category;
        public float ProductPrice => _productPrice;
        #endregion

        #region Private Methods
        #endregion

        #region Public Methods
        public void SetInfoProduct( int productID, string productName, int catalogID, string category, float price)
        {
            _productID = productID;
            _productName = productName;
            _referenceCatalogID = catalogID;
            _category = category; ;
            _productPrice = price;
        }

        public void SetReferenceCatalog(int catalogID)
        {
            _referenceCatalogID = catalogID;
        }

        public override string ToString()
        {
            return $"Name: {_productName}; ID: {_productID}; Price: {ProductPrice}; Category: {Category}; Reference Catalog ID: {_referenceCatalogID}.";
        }
        #endregion
    }
}
