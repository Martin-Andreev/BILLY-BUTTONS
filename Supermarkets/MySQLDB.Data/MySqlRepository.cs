namespace MySQLDB.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using MSSQL.Data;
    using Supermarket.Models;

    public static class MySqlRepository
    {
        public static IList<Vendor> GetAllData()
        {
            var context = new MySQLContext();
            var vendors = context.Vendors.ToList();

            return vendors;
        }

        public static void ReplicateMssqlData(MSSQLContext data)
        {
            MySQLContext context = new MySQLContext();
            var vendors = data.Vendors;
            var measures = data.Measures;
            var supermarkets = data.Supermarkets;
            var products = data.Products;
            var sales = data.Sales;
            var expenses = data.Expenses;

            ReplicateVendor(context, vendors);

            ReplicateMeasure(context, measures);

            ReplicateSupermarket(context, supermarkets);

            ReplicateProduct(context, products);

            ReplicateSales(sales, context);

            ReplicateExpenses(expenses, context);
        }

        private static void ReplicateExpenses(IQueryable<Expense> expenses, MySQLContext context)
        {
            foreach (var expense in expenses)
            {
                if (!context.Expenses.Any(e => e.ExpenseDate == expense.ExpenseDate && e.Vendor.Name == expense.Vendor.Name))
                {
                    var newExpense = new Expense()
                    {
                        VendorId = expense.Vendor.Id,
                        ExpenseDate = expense.ExpenseDate,
                        ExpenseSum = expense.ExpenseSum
                    };

                    context.Expenses.Add(newExpense);

                    context.SaveChanges();
                }
            }
        }

        private static void ReplicateSales(IQueryable<Sale> sales, MySQLContext context)
        {
            foreach (var sale in sales)
            {
                if (!context.Sales.Any(s =>
                    s.Supermarket.Name == sale.Supermarket.Name && s.Product.Name == sale.Product.Name &&
                    s.SaleDate == sale.SaleDate))
                {
                    var newSale = new Sale()
                    {
                        SupermarketId = sale.Supermarket.Id,
                        ProductId = sale.Product.Id,
                        SaleDate = sale.SaleDate,
                        SalePrice = sale.SalePrice,
                        Quantity = sale.Quantity
                    };

                    context.Sales.Add(newSale);

                    context.SaveChanges();
                }
            }
        }

        private static void ReplicateSupermarket(MySQLContext context, IQueryable<Supermarket> supermarkets)
        {
            foreach (var supermarket in supermarkets)
            {
                if (!context.Supermarkets.Any(s => s.Name == supermarket.Name))
                {
                    var newSupermarket = new Supermarket()
                    {
                        Name = supermarket.Name
                    };

                    context.Supermarkets.Add(newSupermarket);

                    context.SaveChanges();
                }
            }
        }

        private static void ReplicateProduct(MySQLContext context, IQueryable<Product> products)
        {
            foreach (var product in products)
            {
                if (!context.Products.Any(p => p.Name == product.Name))
                {
                    var newProduct = new Product()
                    {
                        Name = product.Name,
                        Price = product.Price,
                        VendorId = product.Vendor.Id,
                        MeasureId = product.Measure.Id
                    };

                    context.Products.Add(newProduct);

                    context.SaveChanges();
                }
            }
        }

        private static void ReplicateMeasure(MySQLContext context, IQueryable<Measure> measures)
        {
            foreach (var measure in measures)
            {
                if (!context.Measures.Any(m => m.Name == measure.Name))
                {
                    var newMeasure = new Measure()
                    {
                        Name = measure.Name
                    };

                    context.Measures.Add(newMeasure);

                    context.SaveChanges();
                }
            }
        }

        private static void ReplicateVendor(MySQLContext context, IQueryable<Vendor> vendors)
        {
            foreach (var vendor in vendors)
            {
                if (!context.Vendors.Any(v => v.Name == vendor.Name))
                {
                    var newVendor = new Vendor()
                    {
                        Name = vendor.Name
                    };

                    context.Vendors.Add(newVendor);

                    context.SaveChanges();
                }
            }
        }
    }
}