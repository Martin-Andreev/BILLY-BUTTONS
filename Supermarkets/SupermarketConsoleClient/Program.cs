namespace SupermarketConsoleClient
{
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using MSSQL.Data;
    using Oracle.Data;
    //using Oracle.Data.Migrations;
    using System.IO.Compression;
    using System.IO;
    using Excel;
    using Supermarket.Models;

    public class SupermarketMain
    {
        public static void Main()
        {
            var products = SQLLite.Data.SqLiteRepository.GetProductTaxesData();

            Console.WriteLine(products.Count);
            return;
            foreach (var product in products)
            {
                Console.WriteLine("{0} -> {1}", product.Key, product.Value);
            }
        }
    }
}