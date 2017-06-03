namespace BankSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;
    using Migrations;

    public class BankSystemContext : DbContext
    {
        public BankSystemContext()
            : base("name=BankSystemContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<BankSystemContext, Configuration>());
        }

        public virtual DbSet<Account> Accounts { get; set; }

        public virtual DbSet<User> Users { get; set; }
    }
}