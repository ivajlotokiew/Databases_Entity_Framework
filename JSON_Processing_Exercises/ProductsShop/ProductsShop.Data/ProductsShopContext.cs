namespace ProductsShop.Data
{
    using Migrations;
    using ProductShop.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProductsShopContext : DbContext
    {
        // Your context has been configured to use a 'ProductsShopContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'ProductsShop.Data.ProductsShopContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'ProductsShopContext' 
        // connection string in the application configuration file.
        public ProductsShopContext()
            : base("name=ProductsShopContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<ProductsShopContext, Configuration>());
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(user => user.Friends)
                .WithMany()
                .Map(config =>
                {
                    config.MapLeftKey("userId");
                    config.MapRightKey("friendId");
                    config.ToTable("UserFriends");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}