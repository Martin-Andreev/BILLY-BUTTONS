namespace MSSQL.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using Oracle.Models;
    using Supermarket.Models;
    using Utilities;

    public static class MSSQLRepository
    {
        public static List<VendorSalesReport> GetSalesByVendor(DateTime startDate, DateTime endDate)
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

        public static IList<SalesReport> GetSalesByProduct(DateTime startDate, DateTime endDate)
        {
            var context = new MSSQLContext();

            var reports = context.Sales
                .Where(s => s.SaleDate >= startDate && s.SaleDate <= endDate)
                .GroupBy(s => new
                {
                    productId = s.ProductId,
                    productName = s.Product.Name,
                    vendorName = s.Product.Vendor.Name
                })
                .Select(s => new SalesReport
                {
                    ProductId = s.Key.productId,
                    ProductName = s.Key.productName,
                    VendorName = s.Key.vendorName,
                    TotalQuantitySold = s.Sum(tqs => tqs.Quantity),
                    TotalIncomes = s.Sum(ti => ti.Quantity * ti.SalePrice)
                });

            var vendorsSalesReport = new List<SalesReport>();
            vendorsSalesReport.AddRange(reports);

            return vendorsSalesReport;
        }

        public static void ReplicateOracleData(IList<ProductDTO> data)
        {
            var context = new MSSQLContext();

            foreach (var product in data)
            {
                if (!context.Products.Any(p => p.Name == product.Name))
                {
                    Vendor vendor = GetProductVendor(context, product);

                    Measure measure = GetProductMeasure(context, product);

                    var newProduct = new Product()
                    {
                        Name = product.Name,
                        Measure = measure,
                        Vendor = vendor,
                        Price = product.Price
                    };

                    context.Products.Add(newProduct);
                    context.SaveChanges();
                }
            }
        }

        public static IList<Product> GetAllData(MSSQLContext context)
        {
            var data = context.Products
                .Include(p => p.Measure)
                .Include(p => p.Sales)
                .Include(p => p.Sales.Select(s => s.Supermarket))
                .Include(p => p.Vendor)
                .Include(p => p.Vendor.Expenses)
                .ToList();

            return data;
        }

        private static Measure GetProductMeasure(MSSQLContext context, ProductDTO product)
        {
            if (!context.Measures.Any(v => v.Name == product.Measure.Name))
            {
                var measure = new Measure()
                {
                    Name = product.Measure.Name
                };

                context.Measures.Add(measure);
                return measure;
            }

            return context.Measures.First(v => v.Name == product.Measure.Name);
        }

        private static Vendor GetProductVendor(MSSQLContext context, ProductDTO product)
        {
            if (!context.Vendors.Any(v => v.Name == product.Vendor.Name))
            {
                var vendor = new Vendor()
                {
                    Name = product.Vendor.Name
                };

                context.Vendors.Add(vendor);
                return vendor;
            }

            return context.Vendors.First(v => v.Name == product.Vendor.Name);
        }
    }
}