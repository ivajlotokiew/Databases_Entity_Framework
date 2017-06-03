namespace Sales.Data.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Sales.Data.SalesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Sales.Data.SalesContext context)
        {
            if (context.Customers.Any())
            {
                return;
            }

            context.Customers.AddOrUpdate(
              e => e.Email,
                new Customer { Name = "Andrew Columns", Email = "columns@abv.bg", CreditCardNumber = "0xx03dfs00s" },
                new Customer { Name = "Brice Lambson", Email = "lambson@abv.bg", CreditCardNumber = "sdf4bcgfdfs00s" },
                new Customer { Name = "Rowan Miller", Email = "miller@abv.bg", CreditCardNumber = "sfdsf43sdf3" }
              );

        }
    }
}
