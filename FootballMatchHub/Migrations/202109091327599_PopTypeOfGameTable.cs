namespace FootballMatchHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopTypeOfGameTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO TypeOfGames (Id, Name) VALUES (1, 'A-Team Game')");
            Sql("INSERT INTO TypeOfGames (Id, Name) VALUES (2, 'U-Team Game')");
            Sql("INSERT INTO TypeOfGames (Id, Name) VALUES (3, 'Cup Game')");
        }

        public override void Down()
        {
            Sql("DELETE FROM TypeOfGames WHERE Id IN (1,2,3)");
        }
    }
}
