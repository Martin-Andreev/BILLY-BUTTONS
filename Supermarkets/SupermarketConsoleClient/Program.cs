namespace SupermarketConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Oracle.Data;
    using Supermarket.Models;

    public class SupermarketMain
    {
        public static void Main()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<OracleDbContex>());
            OracleDbContex contex = new OracleDbContex();

            var supermarket = new Supermarket
            {
                Name = "Billa",
            };

            contex.Supermarkets.Add(supermarket);
            contex.SaveChanges();

            Console.WriteLine(contex.Supermarkets.Count());
        }
    }
}