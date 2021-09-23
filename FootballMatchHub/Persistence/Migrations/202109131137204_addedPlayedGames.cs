namespace FootballMatchHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPlayedGames : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlayedGames",
                c => new
                    {
                        MatchId = c.Int(nullable: false),
                        PlayerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.MatchId, t.PlayerId })
                .ForeignKey("dbo.Matches", t => t.MatchId)
                .ForeignKey("dbo.AspNetUsers", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.MatchId)
                .Index(t => t.PlayerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PlayedGames", "PlayerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PlayedGames", "MatchId", "dbo.Matches");
            DropIndex("dbo.PlayedGames", new[] { "PlayerId" });
            DropIndex("dbo.PlayedGames", new[] { "MatchId" });
            DropTable("dbo.PlayedGames");
        }
    }
}
