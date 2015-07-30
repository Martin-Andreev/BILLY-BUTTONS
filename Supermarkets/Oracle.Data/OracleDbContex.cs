namespace Oracle.Data
{
    using System.Data.Entity;
    using Migrations;
    //using Migrations;
    using Models;
    using Supermarket.Models;

    public class OracleDbContex : DbContext
    {
        public OracleDbContex()
            : base("OracleDbContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OracleDbContex, Configuration>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<OracleDbContex>());
        }

        public IDbSet<ProductDTO> Products { get; set; }
        
        public IDbSet<VendorDTO> Vendors { get; set; }

        public IDbSet<MeasureDTO> Measures { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TEAMWORK");
            base.OnModelCreating(modelBuilder);
        }
    }
}
