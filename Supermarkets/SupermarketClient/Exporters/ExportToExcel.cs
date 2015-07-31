namespace SupermarketClient.Exporters
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using Microsoft.Office.Interop.Excel;
    using Supermarket.Models;
    using Utilities;
    using SQL = System.Data;

    public class ExportToExcel
    {
        public static void ExportVendorsReports(Dictionary<string, int> products, IList<Vendor> vendors)
        {
            string path = Environment.CurrentDirectory + @"..\..\..\Exported-Files\Product-Financial-Report.xlsx";
          
            var file = new Application();

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
                Worksheet worksheet = excelWorkBook.Sheets.Add();
                worksheet.Name = table.TableName;

                for (int tableColumn = 1; tableColumn < table.Columns.Count + 1; tableColumn++)
                {
                    worksheet.Cells[1, tableColumn] = table.Columns[tableColumn - 1].ColumnName;
                }

                for (int tableRow = 0; tableRow < table.Rows.Count; tableRow++)
                {
                    for (int tableColumn = 0; tableColumn < table.Columns.Count; tableColumn++)
                    {
                        worksheet.Cells[tableRow + 2, tableColumn + 1] = table.Rows[tableRow].ItemArray[tableColumn].ToString();
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

                decimal expensesSum = vendorExpenses.Sum(vendorExpense => vendorExpense.ExpenseSum);
                var vendorProducts = vendor.Products.ToList();
                
                decimal totalTaxes = 0m;
                decimal incomesSum = 0;
                double tax = 0;

                incomesSum = CalculateVendorReport(products, vendorProducts, tax, incomesSum, ref totalTaxes);

                decimal financialResult = incomesSum - expensesSum - totalTaxes;

                VendorSale sale = new VendorSale(vendorName, incomesSum, expensesSum, totalTaxes, financialResult);
                sales.Add(sale);
            }
        }

        private static decimal CalculateVendorReport(Dictionary<string, int> products, List<Product> vendorProducts, double tax, decimal incomesSum,
            ref decimal totalTaxes)
        {
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
                    decimal productIncome = productSale.SalePrice*productSale.Quantity;
                    incomesSum += productIncome;
                    totalTaxes += (productIncome)*((decimal) tax/100);
                }
            }
            return incomesSum;
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
