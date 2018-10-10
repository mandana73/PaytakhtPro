namespace BICT.Payetakht.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BICT.Payetakht.Data.BICTDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BICT.Payetakht.Data.BICTDbContext context)
        {
        }
    }
}
