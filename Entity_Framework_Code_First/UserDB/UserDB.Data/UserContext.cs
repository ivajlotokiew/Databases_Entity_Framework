namespace UserDB.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;
    using Migrations;

    public class UserContext : DbContext
    {
        public UserContext()
            : base("name=UserContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<UserContext, Configuration>());
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Town> Towns { get; set; }

        public virtual DbSet<Country> Countries { get; set; }
    }
}