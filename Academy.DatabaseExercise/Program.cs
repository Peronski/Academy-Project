using System;
using Entities.Products;

namespace Academy.DatabaseExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Product product = new Product("Anello", 1);
            Console.WriteLine(product.ToString());
        }
    }
}
