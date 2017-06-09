namespace StupidChessBase.Data.Migrations.Clubs
{
    using Models.SqlLiteModels;
    using System.Data.Entity.Migrations;
    using System.Data.SQLite.EF6.Migrations;

    internal sealed class SqlLiteConfig : DbMigrationsConfiguration<Contexts.ClubContext>
    {
        public SqlLiteConfig()
        {
            SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Clubs";
        }

        protected override void Seed(Contexts.ClubContext context)
        {
            context.Clubs.Add(new Club() { Name = "Real Madrid" });
            context.Clubs.Add(new Club() { Name = "Juventus" });
        }
    }
}
