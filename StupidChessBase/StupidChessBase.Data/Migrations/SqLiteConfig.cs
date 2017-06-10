namespace StupidChessBase.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Data.SQLite.EF6.Migrations;

    internal sealed class SqLiteConfig : DbMigrationsConfiguration<StupidChessBase.Data.Contexts.ClubContext>
    {
        public SqLiteConfig()
        {
            SetSqlGenerator("System.Data.SQLite", new SQLiteMigrationSqlGenerator());
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations";
        }
    }
}
