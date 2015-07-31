namespace SupermarketClient.Importerts
{
    using System;
    using System.Linq;
    using System.Transactions;
    using System.Xml.Linq;
    using MSSQL.Data;
    using Supermarket.Models;

    public static class ImportFromXML
    {
        public static void ImportVendorExpenses(string file)
        {
            MSSQLContext context = new MSSQLContext();

            XDocument xmlDoc = XDocument.Load(file);
            var vendors = xmlDoc.Descendants("vendor");

            foreach (var vendor in vendors)
            {
                string vendorName = vendor.Attribute("name").Value;
                var wantedVendor = context.Vendors.FirstOrDefault(v => v.Name == vendorName);

                if (wantedVendor == null)
                {
                    wantedVendor = AddNewVendor(vendorName, context);
                }

                AddVendorExpenses(vendor, wantedVendor, context);
            }
        }

        private static Vendor AddNewVendor(string vendorName, MSSQLContext context)
        {
            var newVendor = new Vendor()
            {
                Name = vendorName
            };

            context.Vendors.Add(newVendor);
            return newVendor;
        }

        private static void AddVendorExpenses(XElement vendor, Vendor wantedVendor, MSSQLContext context)
        {
            var expenses = vendor.Descendants("expenses");

            foreach (var expense in expenses)
            {
                using (TransactionScope transaction = new TransactionScope())
                {
                    try
                    {
                        decimal expenseSum = decimal.Parse(expense.Value);
                        DateTime expenseDate = DateTime.Parse(expense.Attribute("month").Value);

                        var newExpense = new Expense()
                        {
                            ExpenseDate = expenseDate,
                            ExpenseSum = expenseSum
                        };

                        wantedVendor.Expenses.Add(newExpense);
                        context.SaveChanges();
                        transaction.Complete();
                    }
                    catch (Exception e)
                    {
                        transaction.Dispose();
                    }
                }
            }
        }
    }
}
