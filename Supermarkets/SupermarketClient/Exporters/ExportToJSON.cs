namespace SupermarketClient.Exporters
{
    using System.Collections.Generic;
    using System.IO;
    using MongoDB.Bson;
    using MongoDB.Driver;
    using MSSQL.Data.Utilities;


    public static class ExportToJSON
    {
        public static void ExportSalesByProductReport(IList<SalesReport> reports)
        {
            const string path = @"..\..\Json-Reports\";

            var client = new MongoClient();
            var database = client.GetDatabase("Reports");
            database.DropCollectionAsync("SalesByProductReports");
            var collection = database.GetCollection<BsonDocument>("SalesByProductReports");

            ClearDirectory(path);

            foreach (var report in reports)
            {
                var currentReport = new BsonDocument
                {
                    { "product-id", report.ProductId},
                    {"product-name", report.ProductName},
                    {"vendor-name", report.VendorName},
                    {"total-quantity-sold", report.TotalQuantitySold},
                    {"total-incomes", report.TotalIncomes.ToString()}
                };

                File.WriteAllText(path + report.ProductId + ".json", currentReport.ToJson());
                collection.InsertOneAsync(currentReport).Wait();
            }
        }

        private static void ClearDirectory(string path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            Directory.CreateDirectory(path);
        }
    }
}
