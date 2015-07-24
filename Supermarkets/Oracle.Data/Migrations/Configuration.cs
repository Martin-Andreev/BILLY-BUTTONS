namespace Oracle.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public sealed class Configuration : DbMigrationsConfiguration<OracleDbContex>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Oracle.Data.OracleDbContex";
        }

        protected override void Seed(OracleDbContex context)
        {
        }
    }
}
