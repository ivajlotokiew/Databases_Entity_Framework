namespace UserDB.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration
        : DbMigrationsConfiguration<UserContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            this.ContextKey = "UserDB.Data.UserContext";
        }

        protected override void Seed(UserContext context)
        {
            base.Seed(context);
        }
    }
}
