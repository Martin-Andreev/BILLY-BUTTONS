namespace Supermarket.Database.Mysql.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Supermarket.Database.Mysql.Data.SupermarketsMysqlContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Supermarket.Database.Mysql.Data.SupermarketsMysqlContext";
        }

        protected override void Seed(Supermarket.Database.Mysql.Data.SupermarketsMysqlContext context)
        { 
        }
    }
}
