namespace FootballMatchHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToAppUserAndPropsToMatch : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Matches", "MatchSummary", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Matches", "Season", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Name");
            DropColumn("dbo.Matches", "Season");
            DropColumn("dbo.Matches", "MatchSummary");
        }
    }
}
