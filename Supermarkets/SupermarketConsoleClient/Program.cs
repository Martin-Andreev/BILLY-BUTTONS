namespace SupermarketConsoleClient
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Transactions;
    using System.Xml.Linq;
    using MSSQL.Data;
    using MSSQL.Data.Migrations;
    using Supermarket.Models;


    public class SupermarketMain
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MSSQLContext, Configuration>());
            MSSQLContext context = new MSSQLContext();

            XDocument xmlDoc = XDocument.Load("../../Sample-Vendor-Expenses.xml");
            var vendors = xmlDoc.Descendants("vendor");

            foreach (var vendor in vendors)
            {
                string vendorName = vendor.Attribute("name").Value;
                var wantedVendor = context.Vendors.FirstOrDefault(v => v.Name == vendorName);

                if (wantedVendor == null)
                {
                    var newVendor = new Vendor()
                    {
                        Name = vendorName
                    };

                    context.Vendors.Add(newVendor);
                    wantedVendor = newVendor;
                }

                var expenses = vendor.Descendants("expenses");

                foreach (var expense in expenses)
                {
                    using (TransactionScope transaction = new TransactionScope())
                    {
                        try
                        {
                            decimal expenseSum = decimal.Parse(expense.Value);
                            DateTime expenseDate = DateTime.Parse(expense.Attribute("month").Value);
                            
                            wantedVendor.Expenses.Add(new Expense()
                            {
                                ExpenseDate = expenseDate,
                                ExpenseSum = expenseSum
                            });

                            context.SaveChanges();
                            Console.WriteLine(wantedVendor.Id);
                            transaction.Complete();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            transaction.Dispose();
                        }
                    }
                }
            }
        }
    }
}