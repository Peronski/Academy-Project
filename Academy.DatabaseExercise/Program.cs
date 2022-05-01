using System;
using Entities.Products;
using Entities.Catalogs;
using FileHelper.Reader;
using FileHelper.Writer;

namespace Academy.DatabaseExercise
{
    internal class Program
    {
        private const string DATA_PATH_CATALOGHI = @"D:\Cataloghi";
        private const string DATA_PATH_PRODOTTI = @"D:\Prodotti";

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Product anello = new Product("Anello", 101);
            Product bracciale = new Product("Bracciale", 102);
            Product collana = new Product("Collana", 103);
            Product orecchini = new Product("Orecchini", 104);

            Catalog catalog = new Catalog("Gioielli", 1, anello, bracciale, collana, orecchini);

            //FileWriter.AddCatalog(catalog, DATA_PATH_CATALOGHI, true);
            //FileWriter.AddProduct(orecchini, DATA_PATH_PRODOTTI, true);
            //FileWriter.AddProduct(bracciale, DATA_PATH_PRODOTTI, true);
            //FileWriter.AddProduct(collana, DATA_PATH_PRODOTTI, true);
            //FileWriter.AddProduct(orecchini, DATA_PATH_PRODOTTI, true);

            FileWriter.AddCatalog(catalog, DATA_PATH_CATALOGHI, true);

            //FileReader.ReadCatalogs(DATA_PATH_CATALOGHI, DATA_PATH_PRODOTTI);
        }
    }
}
