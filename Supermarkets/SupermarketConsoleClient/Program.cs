
namespace SupermarketConsoleClient
{

    using MongoDB.Bson;
    using MongoDB.Driver;
    using System;
    using System.IO;
    using MSSQL.Data;

    public class SupermarketMain
    {
        public static void Main()
        {
            string subDirectory = "../../Json-Reports";

            var client = new MongoClient();
            var database = client.GetDatabase("Reports");
            database.DropCollectionAsync("SalesByProductReports");
            var dbReports = database.GetCollection<Reports>("SalesByProductReports");

            DirectoryInfo di = new DirectoryInfo(subDirectory);
            try
            {
                di.Delete(true);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            di = Directory.CreateDirectory(subDirectory);

            var context = new MSSQLContext();

            string querySelect =
                (@"SELECT 
                    s.ProductId as product_id,
                    p.Name as product_name,
                    v.Name as vendor_name,
                    SUM(s.Quantity) as total_quantity_sold, 
                    SUM(s.Quantity * s.SalePrice) as total_incomes
                FROM Sales s
                INNER JOIN Products p ON p.Id = s.ProductId
                INNER JOIN Vendors v ON v.Id = p.VendorId
                GROUP BY ProductId, p.Name, v.Name");

            //WHERE startDate and endDate /|\

            var reports = context.Database.SqlQuery<Reports>(querySelect);

            foreach (var report in reports)
            {
                string result = report.ToJson().Replace('_', '-');
                File.WriteAllText("../../Json-Reports/" + report.product_id + ".json", result);

                dbReports.InsertOneAsync(report).Wait();

                Console.WriteLine(result);
            }
        }
    }
}