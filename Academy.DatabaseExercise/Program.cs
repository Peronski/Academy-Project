using System;
using System.Collections.Generic;
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
            // *** Creazione oggetti ***

            //Product anello = new Product(101, "Anello", "Gioielli", 99f);
            //Product bracciale = new Product(102, "Bracciale", "Gioielli", 129f);
            //Product collana = new Product(103, "Collana", "Gioielli", 230f);
            //Product orecchini = new Product(104, "Orecchini", "Gioielli", 75f);

            //Catalog catalog = new Catalog("Catalogo Gioielli", 1, "Gioielli", anello, bracciale, collana, orecchini);

            // *** Scrittura file ***

            //FileWriter.AddProduct(anello, DATA_PATH_PRODOTTI, true);
            //FileWriter.AddProduct(bracciale, DATA_PATH_PRODOTTI, true);
            //FileWriter.AddProduct(collana, DATA_PATH_PRODOTTI, true);
            //FileWriter.AddProduct(orecchini, DATA_PATH_PRODOTTI, true);

            //FileWriter.AddCatalog(catalog, DATA_PATH_CATALOGHI, true);

            // *** Lettura file ***

            List<Catalog> catalogs = FileReader.ReadCatalogs(DATA_PATH_CATALOGHI, DATA_PATH_PRODOTTI);

            foreach (Catalog catalog in catalogs)
                Console.WriteLine(catalog.ToString());
        }
    }
}
