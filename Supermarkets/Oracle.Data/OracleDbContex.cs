namespace Oracle.Data
{
    using System.Data.Entity;
    using Supermarket.Models;

    public class OracleDbContex : DbContext
    {
        public OracleDbContex()
            : base("OracleDbContext")
        {
        }

         public IDbSet<Expense> Expenses { get; set; }
        
        public IDbSet<Product> Products { get; set; }
        
        public IDbSet<Sale> Sales { get; set; }
        
        public IDbSet<Supermarket> Supermarkets { get; set; }

        public IDbSet<Vendor> Vendors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ANDREEV");
            base.OnModelCreating(modelBuilder);
        }
    }
}
