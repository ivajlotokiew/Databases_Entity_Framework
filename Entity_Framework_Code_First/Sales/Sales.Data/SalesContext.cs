namespace Sales.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;
    using Data.Migrations;

    public class SalesContext : DbContext
    {
        public SalesContext()
            : base("name=SalesContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<SalesContext, Configuration>());
        }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Sale> Sales { get; set; }

        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<StoreLocation> StoreLocation { get; set; }
    }
}