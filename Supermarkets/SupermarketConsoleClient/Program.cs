
namespace SupermarketConsoleClient
{
    using System.Linq;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System;
    using System.IO;
    using MSSQL.Data;

    public class SupermarketMain
    {
        public static void Main()
        {

            var client = new MongoClient();
            var database = client.GetDatabase("Reports");
            database.DropCollectionAsync("SalesByProductReports");
            var collection = database.GetCollection<BsonDocument>("SalesByProductReports");

            string path = @"..\..\Json-Reports\";
            ClearDirectory(path);

            var context = new MSSQLContext();

            var reports = context.Sales
                .Where(s => s.SaleDate <= DateTime.Now) //Please add correct startDate and endDate
                .GroupBy(s => new
                {
                    product_id = s.ProductId,
                    product_name = s.Product.Name,
                    vendor_name = s.Product.Vendor.Name
                })
                .Select(s => new
                {
                    product_id = s.Key.product_id,
                    product_name = s.Key.product_name,
                    vendor_name = s.Key.vendor_name,
                    total_quantity_sold = s.Sum(tqs => tqs.Quantity),
                    total_incomes = s.Sum(ti => ti.Quantity * ti.SalePrice)
                });

            foreach (var report in reports)
            {
                var currentReport = new BsonDocument
                {
                    { "product-id", report.product_id},
                    {"product-name", report.product_name},
                    {"vendor-name", report.vendor_name},
                    {"total-quantity-sold", report.total_quantity_sold},
                    {"total-incomes", report.total_incomes.ToString()}
                };

                File.WriteAllText(path + report.product_id + ".json", currentReport.ToJson());
                collection.InsertOneAsync(currentReport).Wait();
            }
        }
        private static void ClearDirectory(string path)
        {
            if (Directory.Exists(path))//if folder exists
            {
                Directory.Delete(path, true);//recursive delete (all subdirs, files)
            }
            Directory.CreateDirectory(path);//creates empty directory
        }
    }
}