namespace CoachLancer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGroups : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TrainingsPerWeek = c.Int(nullable: false),
                        Coach_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Coach_Id)
                .Index(t => t.Coach_Id);
            
            CreateTable(
                "dbo.PlayerGroups",
                c => new
                    {
                        Player_Id = c.String(nullable: false, maxLength: 128),
                        Groups_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Player_Id, t.Groups_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.Player_Id, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.Groups_Id, cascadeDelete: true)
                .Index(t => t.Player_Id)
                .Index(t => t.Groups_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groups", "Coach_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PlayerGroups", "Groups_Id", "dbo.Groups");
            DropForeignKey("dbo.PlayerGroups", "Player_Id", "dbo.AspNetUsers");
            DropIndex("dbo.PlayerGroups", new[] { "Groups_Id" });
            DropIndex("dbo.PlayerGroups", new[] { "Player_Id" });
            DropIndex("dbo.Groups", new[] { "Coach_Id" });
            DropTable("dbo.PlayerGroups");
            DropTable("dbo.Groups");
        }
    }
}
