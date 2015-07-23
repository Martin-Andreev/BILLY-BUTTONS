namespace MySQLDB.Data
{
    using MySql.Data.Entity;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Supermarket.Models;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MySQLContext : DbContext
    {
        
        public MySQLContext()
            : base("name=MySQLContext")
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