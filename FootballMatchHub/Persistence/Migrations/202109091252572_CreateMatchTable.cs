namespace FootballMatchHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMatchTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Datetime = c.DateTime(nullable: false),
                        HomeTeam = c.String(),
                        AwayTeam = c.String(),
                        Result = c.String(),
                        Goals = c.Int(nullable: false),
                        Assists = c.Int(nullable: false),
                        YCard = c.Int(nullable: false),
                        RCard = c.Int(nullable: false),
                        MinPlayed = c.Int(nullable: false),
                        PosPlayed = c.Int(nullable: false),
                        Player_Id = c.String(maxLength: 128),
                        TypeOfGame_Id = c.Byte(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Player_Id)
                .ForeignKey("dbo.TypeOfGames", t => t.TypeOfGame_Id)
                .Index(t => t.Player_Id)
                .Index(t => t.TypeOfGame_Id);
            
            CreateTable(
                "dbo.TypeOfGames",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matches", "TypeOfGame_Id", "dbo.TypeOfGames");
            DropForeignKey("dbo.Matches", "Player_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Matches", new[] { "TypeOfGame_Id" });
            DropIndex("dbo.Matches", new[] { "Player_Id" });
            DropTable("dbo.TypeOfGames");
            DropTable("dbo.Matches");
        }
    }
}
