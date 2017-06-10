namespace StupidChessBase.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class SqLiteConfig : DbMigrationsConfiguration<StupidChessBase.Data.Contexts.ClubContext>
    {
        public SqLiteConfig()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations";
        }

        protected override void Seed(Contexts.ClubContext context)
        {

        }
    }
}
