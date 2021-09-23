namespace FootballMatchHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangestoNotification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notifications", "OriginalHomeTeam", c => c.String());
            AddColumn("dbo.Notifications", "OriginalAwayTeam", c => c.String());
            AddColumn("dbo.Notifications", "OriginalResult", c => c.String());
            AddColumn("dbo.Notifications", "OriginalMatchSummary", c => c.String());
            AddColumn("dbo.Notifications", "OriginalSeason", c => c.Int(nullable: false));
            AddColumn("dbo.Notifications", "OriginalGoals", c => c.Int(nullable: false));
            AddColumn("dbo.Notifications", "OriginalAssists", c => c.Int(nullable: false));
            AddColumn("dbo.Notifications", "OriginalYCard", c => c.Int(nullable: false));
            AddColumn("dbo.Notifications", "OriginalRCard", c => c.Int(nullable: false));
            AddColumn("dbo.Notifications", "OriginalMinPlayed", c => c.Int(nullable: false));
            AddColumn("dbo.Notifications", "OriginalPosPlayed", c => c.String());
            AddColumn("dbo.Notifications", "OriginalTypeOfGame_Id", c => c.Byte());
            CreateIndex("dbo.Notifications", "OriginalTypeOfGame_Id");
            AddForeignKey("dbo.Notifications", "OriginalTypeOfGame_Id", "dbo.TypeOfGames", "Id");
            DropColumn("dbo.Notifications", "OriginalVenue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notifications", "OriginalVenue", c => c.String());
            DropForeignKey("dbo.Notifications", "OriginalTypeOfGame_Id", "dbo.TypeOfGames");
            DropIndex("dbo.Notifications", new[] { "OriginalTypeOfGame_Id" });
            DropColumn("dbo.Notifications", "OriginalTypeOfGame_Id");
            DropColumn("dbo.Notifications", "OriginalPosPlayed");
            DropColumn("dbo.Notifications", "OriginalMinPlayed");
            DropColumn("dbo.Notifications", "OriginalRCard");
            DropColumn("dbo.Notifications", "OriginalYCard");
            DropColumn("dbo.Notifications", "OriginalAssists");
            DropColumn("dbo.Notifications", "OriginalGoals");
            DropColumn("dbo.Notifications", "OriginalSeason");
            DropColumn("dbo.Notifications", "OriginalMatchSummary");
            DropColumn("dbo.Notifications", "OriginalResult");
            DropColumn("dbo.Notifications", "OriginalAwayTeam");
            DropColumn("dbo.Notifications", "OriginalHomeTeam");
        }
    }
}
