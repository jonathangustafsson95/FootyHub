namespace FootballMatchHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpolayername : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "PlayerName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Matches", "PlayerName");
        }
    }
}
