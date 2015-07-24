namespace SupermarketConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using MSSQL.Data;
    using Oracle.Data;
    using MSSQL.Data.Migrations;

    public class SupermarketMain
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MSSQLContext, Configuration>());
            MSSQLContext context = new MSSQLContext();

            Console.WriteLine(context.Vendors.Count());
        }
    }
}