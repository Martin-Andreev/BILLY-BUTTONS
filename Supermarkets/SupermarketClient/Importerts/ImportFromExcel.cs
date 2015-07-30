namespace SupermarketClient.Importerts
{
    using System;
    using System.Data;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using Excel;
    using MSSQL.Data;
    using Supermarket.Models;

    public static class ImportFromExcel
    {
        public static void ImportSalesReports(string file)
        {
            MSSQLContext context = new MSSQLContext();

            using (ZipArchive zip = ZipFile.OpenRead(file))
            {
                foreach (var entry in zip.Entries)
                {
                    if (entry.Name != "")
                    {
                        string[] fileData = entry.FullName.Split('/');
                        DateTime saleDate = DateTime.Parse(fileData[0]);

                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            CopyStream(entry, memoryStream);

                            IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(memoryStream);
                            DataSet result = excelReader.AsDataSet();

                            var rows = result.Tables[0].Rows;
                            int rowsCount = rows.Count;

                            string supermarketName = rows[1][1].ToString();

                            Supermarket supermarket = GetSupermarket(context, supermarketName);

                            AddSaleToDatabase(rowsCount, rows, context, supermarket, saleDate);
                        }
                    }
                }
            }
        }

        private static void CopyStream(ZipArchiveEntry entry, MemoryStream ms)
        {
            var buffer = new byte[16*1024 - 1];
            int read;
            var kur = entry.Open();
            while ((read = kur.Read(buffer, 0, buffer.Length)) > 0)
            {
                ms.Write(buffer, 0, read);
            }
        }

        private static Supermarket GetSupermarket(MSSQLContext context, string supermarketName)
        {
            var supermarket = context.Supermarkets.FirstOrDefault(s => s.Name == supermarketName);

            if (supermarket == null)
            {
                supermarket = new Supermarket()
                {
                    Name = supermarketName
                };

                context.Supermarkets.Add(supermarket);
            }

            return supermarket;
        }

        private static void AddSaleToDatabase(
            int rowsCount,
            DataRowCollection rows,
            MSSQLContext context,
            Supermarket supermarket,
            DateTime saleDate)
        {
            for (int i = 3; i < rowsCount - 1; i++)
            {
                string productName = rows[i][1].ToString();
                int quantity = int.Parse(rows[i][2].ToString());
                decimal price = decimal.Parse(rows[i][3].ToString());

                Product product = context.Products.FirstOrDefault(p => p.Name == productName);

                context.Sales.Add(new Sale()
                {
                    Supermarket = supermarket,
                    Product = product,
                    SaleDate = saleDate,
                    SalePrice = price,
                    Quantity = quantity
                });

                context.SaveChanges();
            }
        }
    }
}
