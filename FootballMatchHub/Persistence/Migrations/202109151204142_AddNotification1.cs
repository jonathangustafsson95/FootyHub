namespace FootballMatchHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotification1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserNotifications",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    NotificationId = c.Int(nullable: false),
                    IsRead = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => new { t.UserId, t.NotificationId })
                .ForeignKey("dbo.Notifications", t => t.NotificationId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.NotificationId);
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Notifications", name: "IX_Match_Id", newName: "IX_Matach_Id");
            RenameColumn(table: "dbo.Notifications", name: "Match_Id", newName: "Matach_Id");
        }
    }
}
