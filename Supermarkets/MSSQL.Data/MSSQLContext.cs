namespace MSSQL.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Supermarket.Models;

    public class MSSQLContext : DbContext
    {
       
        public MSSQLContext()
            : base("name=MSSQLContext")
        {
        }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<Measure> Measures { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Supermarket> Supermarkets { get; set; }

        public DbSet<Vendor> Vendors { get; set; }
    }
}