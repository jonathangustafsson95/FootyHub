namespace FootballMatchHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFkPropertiesToMatch : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Matches", name: "Player_Id", newName: "PlayerId");
            RenameColumn(table: "dbo.Matches", name: "TypeOfGame_Id", newName: "TypeOfGameId");
            RenameIndex(table: "dbo.Matches", name: "IX_Player_Id", newName: "IX_PlayerId");
            RenameIndex(table: "dbo.Matches", name: "IX_TypeOfGame_Id", newName: "IX_TypeOfGameId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Matches", name: "IX_TypeOfGameId", newName: "IX_TypeOfGame_Id");
            RenameIndex(table: "dbo.Matches", name: "IX_PlayerId", newName: "IX_Player_Id");
            RenameColumn(table: "dbo.Matches", name: "TypeOfGameId", newName: "TypeOfGame_Id");
            RenameColumn(table: "dbo.Matches", name: "PlayerId", newName: "Player_Id");
        }
    }
}
