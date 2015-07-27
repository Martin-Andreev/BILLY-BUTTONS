namespace MSSQL.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Supermarket.Models;

    public sealed class Configuration : DbMigrationsConfiguration<MSSQLContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "MSSQL.Data.MSSQLContex";
        }

        protected override void Seed(MSSQLContext context)
        {
            InsertSupermarkets(context);

            InsertMeasures(context);

            InsertVendors(context);

            InsertProducts(context);

            InsertExpenses(context);

            InsertSales(context);
        }

        private void InsertSales(MSSQLContext context)
        {
            if (!context.Sales.Any())
            {
                List<DateTime> dates = new List<DateTime>()
                {
                    new DateTime(2015, 7, 20, 18, 20, 05),
                    new DateTime(2015, 6, 21, 10, 55, 15),
                    new DateTime(2015, 6, 18, 11, 40, 11),
                    new DateTime(2015, 6, 16, 22, 51, 25),
                    new DateTime(2015, 7, 19, 21, 15, 23),
                    new DateTime(2015, 7, 22, 10, 11, 12),
                    new DateTime(2015, 7, 21, 11, 50, 41),
                    new DateTime(2015, 6, 19, 09, 40, 46),
                    new DateTime(2015, 7, 21, 12, 30, 35),
                    new DateTime(2015, 6, 20, 14, 20, 06)
                };

                List<decimal> prices = new List<decimal>()
                {
                    20.0m,
                    30.5m,
                    10.05m,
                    10.8m,
                    120.0m,
                    70.60m,
                    10.55m,
                    30.20m,
                    40.20m,
                    100m

                };

                List<int> quantities = new List<int>() { 3, 5, 10, 2, 19, 4, 50, 1, 7, 14 };

                for (int i = 0; i < 10; i++)
                {
                    var sale = new Sale()
                    {
                        SupermarketId = i + 1,
                        ProductId = i + 1,
                        SaleDate = dates[i],
                        Quantity = quantities[i],
                        SalePrice = prices[i]
                    };

                    context.Sales.Add(sale);
                }

                context.SaveChanges();
            }
        }

        private void InsertExpenses(MSSQLContext context)
        {
            if (!context.Expenses.Any())
            {

                List<decimal> sums = new List<decimal>()
                {
                    1.2m,
                    4.5m,
                    2.65m,
                    1.3m,
                    120.0m,
                    71.60m,
                    10.55m,
                    13.20m,
                    4.50m,
                    700m,
                    5.5m,
                    10m
                };
                List<DateTime> dates = new List<DateTime>()
                {
                    new DateTime(2015, 7, 20, 18, 20, 05),
                    new DateTime(2015, 6, 21, 10, 55, 15),
                    new DateTime(2015, 6, 18, 11, 40, 11),
                    new DateTime(2015, 6, 16, 22, 51, 25),
                    new DateTime(2015, 7, 19, 21, 15, 23),
                    new DateTime(2015, 7, 22, 10, 11, 12),
                    new DateTime(2015, 7, 21, 11, 50, 41),
                    new DateTime(2015, 6, 19, 09, 40, 46),
                    new DateTime(2015, 7, 21, 12, 30, 35),
                    new DateTime(2015, 6, 20, 14, 20, 06),
                    new DateTime(2015, 7, 21, 15, 40, 45),
                    new DateTime(2015, 7, 20, 16, 44, 31)
                };

                for (int i = 0; i < 10; i++)
                {
                    var expense = new Expense()
                    {
                        VendorId = i + 1,
                        ExpenseSum = sums[i],
                        ExpenseDate = dates[i]
                    };

                    context.Expenses.Add(expense);
                }

                for (int i = 10; i < 12; i++)
                {
                    var expense = new Expense()
                    {
                        VendorId = 1,
                        ExpenseSum = sums[i],
                        ExpenseDate = dates[i]
                    };

                    context.Expenses.Add(expense);
                }

                context.SaveChanges();
            }
        }

        private void InsertProducts(MSSQLContext context)
        {
            if (!context.Products.Any())
            {
                List<string> productNames = new List<string>()
                {
                    "Chocolate 'Milka'",
                    "Water 'Baldaran'",
                    "Rakia 'Turgovishte'",
                    "Beer 'Zagorka",
                    "TV Sony",
                    "Samsung E630Z",
                    "Lenovo Y50",
                    "Water 'Bankia'",
                    "Wine 'Han Krum'",
                    "Monster Energy Drink"
                };

                List<decimal> prices = new List<decimal>() { 2.0m, 3.5m, 1.05m, 0.8m, 12.0m, 7.60m, 1.55m, 3.20m, 4.20m, 500m };

                for (int i = 0; i < 10; i++)
                {
                    var product = new Product()
                    {
                        Name = productNames[i],
                        Price = prices[i],
                        VendorId = i + 1,
                        MeasureId = i + 1
                    };

                    context.Products.Add(product);
                }

                context.SaveChanges();
            }
        }

        private void InsertVendors(MSSQLContext context)
        {
            if (!context.Vendors.Any())
            {
                List<string> vendorNames = new List<string>()
                {
                    "Nestle Sofia Corp.",
                    "Zagorka Corp.",
                    "Turgovishte",
                    "Oracle Cor",
                    "Sony",
                    "Samsung",
                    "Lenovo",
                    "Bankia",
                    "Han Krum",
                    "Monster"
                };

                foreach (var name in vendorNames)
                {
                    var vendors = new Vendor()
                    {
                        Name = name,
                    };

                    context.Vendors.Add(vendors);
                }

                context.SaveChanges();
            }
        }

        private void InsertMeasures(MSSQLContext context)
        {
            if (!context.Measures.Any())
            {
                List<string> measureNames = new List<string>()
                {
                    "Kilograms",
                    "Grams",
                    "Liters",
                    "Mililiters",
                    "Pound",
                    "Inch",
                    "Nanometer",
                    "Meter",
                    "Ounce",
                    "Microns"
                };

                foreach (var name in measureNames)
                {
                    var measure = new Measure()
                    {
                        Name = name,
                    };

                    context.Measures.Add(measure);
                }

                context.SaveChanges();
            }
        }

        private static void InsertSupermarkets(MSSQLContext context)
        {
            if (!context.Supermarkets.Any())
            {
                List<string> supermarketNames = new List<string>()
                {
                    "Billa",
                    "Record",
                    "Metro",
                    "Fantastico",
                    "Zora",
                    "Laptops",
                    "Kaufland",
                    "Technopolis",
                    "Technomarket",
                    "SoftUni"
                };

                foreach (var name in supermarketNames)
                {
                    var supermarket = new Supermarket()
                    {
                        Name = name,
                    };

                    context.Supermarkets.Add(supermarket);
                }

                context.SaveChanges();
            }
        }
    }
}
