namespace FootballMatchHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventionsForMatch : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Matches", "Player_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Matches", "TypeOfGame_Id", "dbo.TypeOfGames");
            DropIndex("dbo.Matches", new[] { "Player_Id" });
            DropIndex("dbo.Matches", new[] { "TypeOfGame_Id" });
            AlterColumn("dbo.Matches", "HomeTeam", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Matches", "AwayTeam", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Matches", "Result", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Matches", "PosPlayed", c => c.String(maxLength: 255));
            AlterColumn("dbo.Matches", "Player_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Matches", "TypeOfGame_Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.TypeOfGames", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Matches", "Player_Id");
            CreateIndex("dbo.Matches", "TypeOfGame_Id");
            AddForeignKey("dbo.Matches", "Player_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Matches", "TypeOfGame_Id", "dbo.TypeOfGames", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "TypeOfGame_Id", "dbo.TypeOfGames");
            DropForeignKey("dbo.Matches", "Player_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Matches", new[] { "TypeOfGame_Id" });
            DropIndex("dbo.Matches", new[] { "Player_Id" });
            AlterColumn("dbo.TypeOfGames", "Name", c => c.String());
            AlterColumn("dbo.Matches", "TypeOfGame_Id", c => c.Byte());
            AlterColumn("dbo.Matches", "Player_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Matches", "PosPlayed", c => c.Int(nullable: false));
            AlterColumn("dbo.Matches", "Result", c => c.String());
            AlterColumn("dbo.Matches", "AwayTeam", c => c.String());
            AlterColumn("dbo.Matches", "HomeTeam", c => c.String());
            CreateIndex("dbo.Matches", "TypeOfGame_Id");
            CreateIndex("dbo.Matches", "Player_Id");
            AddForeignKey("dbo.Matches", "TypeOfGame_Id", "dbo.TypeOfGames", "Id");
            AddForeignKey("dbo.Matches", "Player_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
