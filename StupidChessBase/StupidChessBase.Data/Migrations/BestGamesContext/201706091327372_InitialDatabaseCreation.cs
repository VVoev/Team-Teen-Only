namespace StupidChessBase.Data.Migrations.BestGamesContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BestGames",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PgnGame = c.String(),
                    })
                .PrimaryKey(t => t.ID);
        }
        
        public override void Down()
        {
            this.DropTable("dbo.BestGames");
        }
    }
}
