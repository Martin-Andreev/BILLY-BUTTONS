namespace MSSQL.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Utilities;

    public static class MSSQLRepository
    {
        public static List<VendorSalesReport> GetSalesByVendors(DateTime startDate, DateTime endDate)
        {
            var context = new MSSQLContext();

            var expenseGroups = context.Expenses
                .Where(e => e.ExpenseDate > startDate && e.ExpenseDate < endDate)
                .OrderBy(e => e.Vendor.Name)
                .GroupBy(e => e.Vendor)
                .Select(eg => new VendorReport
                {
                    VendorName = eg.Key.Name,
                    Sales = eg
                        .GroupBy(s => DbFunctions.TruncateTime(s.ExpenseDate))
                        .Select(sg => new SaleReport
                        {
                            SaleDate = sg.Key,
                            TotalSum = sg.Sum(s => s.ExpenseSum)
                        }).ToList()
                });

            var vendorsSalesReport = new List<VendorSalesReport>();
            vendorsSalesReport.AddRange(expenseGroups
                .Select(@group => new VendorSalesReport
                {
                    Vendor = @group.VendorName,
                    VendorReports = @group.Sales
                }));

            return vendorsSalesReport;
        }
    }
}
