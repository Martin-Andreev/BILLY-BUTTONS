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
            //MSSQLRepository.ReplicateOracleData(OracleRepository.GetOracleData());
            OracleDbContex context2 = new OracleDbContex();

            Console.WriteLine(context2.Products.Count());
            return;
            MSSQLContext context = new MSSQLContext();

            using (ZipArchive zip = ZipFile.OpenRead(@"../../Sample-Sales-Reports.zip"))
            {
                foreach (var entry in zip.Entries)
                {
                    if (entry.Name != "")
                    {
                        string[] fileData = entry.FullName.Split('/');
                        DateTime saleDate = DateTime.Parse(fileData[0]);

                        using (MemoryStream ms = new MemoryStream())
                        {
                            var buffer = new byte[16 * 1024 - 1];
                            int read;
                            var kur = entry.Open();
                            while ((read = kur.Read(buffer, 0, buffer.Length)) > 0)
                            {
                                ms.Write(buffer, 0, read);
                            }

                            IExcelDataReader excelReader = ExcelReaderFactory.CreateBinaryReader(ms);
                            DataSet result = excelReader.AsDataSet();

                            var rows = result.Tables[0].Rows;
                            int rowsCount = rows.Count;
                           
                            string supermarketName = rows[1][1].ToString();
                            Supermarket supermarket = context.Supermarkets.FirstOrDefault(s => s.Name == supermarketName);

                            if (supermarket == null)
                            {
                                supermarket = new Supermarket()
                                {
                                    Name = supermarketName
                                };

                                context.Supermarkets.Add(supermarket);
                            }

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
            }
        }
    }
}