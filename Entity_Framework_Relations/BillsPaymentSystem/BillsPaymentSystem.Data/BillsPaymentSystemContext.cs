namespace BillsPaymentSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;
    using Migrations;

    public class BillsPaymentSystemContext : DbContext
    {
        public BillsPaymentSystemContext()
            : base("name=BillsPaymentSystemContext")
        {
            Database.SetInitializer(
                new MigrateDatabaseToLatestVersion<BillsPaymentSystemContext, Configuration>());
        }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<BillingDetail> BillingDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CreditCard>().ToTable("CreditCards");
            modelBuilder.Entity<BankAccount>().ToTable("BankAccounts");

            base.OnModelCreating(modelBuilder);
        }
    }
}