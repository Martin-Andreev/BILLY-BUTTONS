namespace SupermarketConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using MSSQL.Data;
   
    using MSSQL.Data.Migrations;
    
   

    public class SupermarketMain
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MSSQLContext, Configuration>());
            MSSQLContext context = new MSSQLContext();
            try
            {
                ExportSalesReportsToPDF.ExportDataToPdf(new DateTime(2015, 6, 18), new DateTime(2015, 6, 20).AddDays(1), context);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine(context.Vendors.Count());
        }
    }
}