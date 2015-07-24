namespace SupermarketConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Oracle.Data;
    using Oracle.Data.Migrations;

    public class SupermarketMain
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OracleDbContex, Configuration>());
            OracleDbContex context = new OracleDbContex();

            Console.WriteLine(context.Supermarkets.Count());
        }
    }
}