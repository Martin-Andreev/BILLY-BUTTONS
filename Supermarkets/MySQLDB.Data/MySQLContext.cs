namespace MySQLDB.Data
{
    using System.Data.Entity;
    using Migrations;
    using MySql.Data.Entity;
    using Supermarket.Models;

    //[DbConfigurationType(typeof(Configuration))]
    public class MySQLContext : DbContext
    {
        
        public MySQLContext()
            : base("name=MySQLContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MySQLContext, Configuration>());
        }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<Measure> Measures { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Supermarket> Supermarkets { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vendor>().HasMany(v => v.Products);
            modelBuilder.Entity<Vendor>().HasMany(v => v.Expenses);
            modelBuilder.Entity<Product>().HasMany(p => p.Sales);
            modelBuilder.Entity<Supermarket>().HasMany(s => s.Sales);
            modelBuilder.Entity<Measure>().HasMany(m => m.Products);

            base.OnModelCreating(modelBuilder);
        }
    }
}