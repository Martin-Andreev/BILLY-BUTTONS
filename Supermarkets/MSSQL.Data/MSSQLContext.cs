namespace MSSQL.Data
{
    using System.Data.Entity;
    using Migrations;
    using Supermarket.Models;

    public class MSSQLContext : DbContext
    {
        public MSSQLContext()
            : base("MSSQLContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MSSQLContext, Configuration>());
        }

        public IDbSet<Expense> Expenses { get; set; }

        public IDbSet<Measure> Measures { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Sale> Sales { get; set; }

        public IDbSet<Supermarket> Supermarkets { get; set; }

        public IDbSet<Vendor> Vendors { get; set; }
    }
}