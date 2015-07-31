namespace SupermarketClient.Exporters
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Supermarket.Models;
    using Utilities;
    using Excel = Microsoft.Office.Interop.Excel;
    using SQL = System.Data;

    public class ExportToExcel
    {
        public static void ExportVendorsReports(Dictionary<string, int> products, IList<Vendor> vendors)
        {
            string path = Environment.CurrentDirectory + @"..\..\..\Product-Financial-Report.xlsx";
            //string path = @"..\..\Product-Financial-Report.xlsx";
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"..\..\Product-Financial-Report.xlsx";

            var file = new Excel.Application();

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            var excelWorkBook = file.Workbooks.Add(Missing.Value);
            List<VendorSale> sales = new List<VendorSale>();
            GetVendorsReport(products, vendors, sales);
            SQL.DataSet set = GetDataSet(sales);

            foreach (SQL.DataTable table in set.Tables)
            {
                Excel.Worksheet worksheet = excelWorkBook.Sheets.Add();
                worksheet.Name = table.TableName;

                for (int i = 1; i < table.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = table.Columns[i - 1].ColumnName;
                }

                for (int j = 0; j < table.Rows.Count; j++)
                {
                    for (int k = 0; k < table.Columns.Count; k++)
                    {
                        worksheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
                    }
                }
            }

            excelWorkBook.SaveAs(path);

            excelWorkBook.Save();
            excelWorkBook.Close();
            file.Quit();
        }

        private static void GetVendorsReport(Dictionary<string, int> products, IList<Vendor> vendors, List<VendorSale> sales)
        {
            foreach (var vendor in vendors)
            {
                string vendorName = vendor.Name;

                var vendorExpenses = vendor.Expenses
                    .Where(e => e.Vendor.Name == vendorName);

                decimal expensesSum = 0m;

                foreach (var vendorExpense in vendorExpenses)
                {
                    expensesSum += vendorExpense.ExpenseSum;
                }

                //var vendorProducts = vendor.Products.ToList();
                var vendorProducts = vendor.Products.ToList();
                
                decimal totalTaxes = 0m;
                decimal incomesSum = 0;

                double tax = 0;


                foreach (var vendorProduct in vendorProducts)
                {
                    if (products.ContainsKey(vendorProduct.Name))
                    {
                        tax = products[vendorProduct.Name];
                    }

                    int productId = vendorProduct.Id;
                    var productSales = vendorProduct.Sales.Where(s => s.ProductId == productId);

                    foreach (var productSale in productSales)
                    {
                        decimal productIncome = productSale.SalePrice * productSale.Quantity;
                        incomesSum += productIncome;
                        totalTaxes += (productIncome) * ((decimal)tax / 100);   
                    }

                    //incomesSum += vendorProduct.Price;
                    //totalTaxes += (vendorProduct.Price) * ((decimal)tax / 100);   

                }

                decimal financialResult = incomesSum - expensesSum - totalTaxes;

                VendorSale sale = new VendorSale(vendorName, incomesSum, expensesSum, totalTaxes, financialResult);
                sales.Add(sale);
            }
        }

        private static SQL.DataSet GetDataSet(List<VendorSale> sales)
        {
            var financialReport = new SQL.DataTable("table");
            financialReport.Columns.Add("Vendor");
            financialReport.Columns.Add("Incomes");
            financialReport.Columns.Add("Expenses");
            financialReport.Columns.Add("Total taxes");
            financialReport.Columns.Add("Financial result");

            sales.ForEach(s => financialReport.Rows.Add(s.Name, s.Incomes, s.Expenses, s.TotalTaxes, s.FinancialResult));

            SQL.DataSet dataSet = new SQL.DataSet("Orgranization");
            dataSet.Tables.Add(financialReport);

            return dataSet;
        }
    }
}
