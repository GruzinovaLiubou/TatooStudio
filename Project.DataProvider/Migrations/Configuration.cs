using System.Data.Entity.Migrations;

namespace Project.DataProvider.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<TatooStudioDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TatooStudioDbContext context)
        {
            // DO NOTHING
        }
    }
}
