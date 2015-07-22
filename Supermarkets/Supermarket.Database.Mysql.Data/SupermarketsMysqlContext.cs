namespace Supermarket.Database.Mysql.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Supermarket.Models;
    using MySql.Data.Entity;
    using Supermarket.Database.Mysql.Data.Migrations;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class SupermarketsMysqlContext : DbContext
    {
        public SupermarketsMysqlContext()
            : base("name=SupermarketsMysqlContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SupermarketsMysqlContext, Configuration>());
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Supermarket> Supermarkets { get; set; }

        public DbSet<Expense> Expenses { get; set; }
    }
}