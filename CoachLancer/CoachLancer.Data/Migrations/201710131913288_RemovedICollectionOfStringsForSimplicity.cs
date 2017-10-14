namespace CoachLancer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedICollectionOfStringsForSimplicity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Position_Id", "dbo.Positions");
            DropForeignKey("dbo.AspNetUsers", "Teams_Id", "dbo.Teams");
            DropForeignKey("dbo.Teams", "Coach_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Gender_Id", "dbo.Genders");
            DropIndex("dbo.AspNetUsers", new[] { "Position_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Teams_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Gender_Id" });
            DropIndex("dbo.Teams", new[] { "Coach_Id" });
            DropColumn("dbo.AspNetUsers", "Position_Id");
            DropColumn("dbo.AspNetUsers", "Teams_Id");
            DropColumn("dbo.AspNetUsers", "Gender_Id");
            DropTable("dbo.Teams");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamSize = c.Int(nullable: false),
                        Coach_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Gender_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Teams_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Position_Id", c => c.Int());
            CreateIndex("dbo.Teams", "Coach_Id");
            CreateIndex("dbo.AspNetUsers", "Gender_Id");
            CreateIndex("dbo.AspNetUsers", "Teams_Id");
            CreateIndex("dbo.AspNetUsers", "Position_Id");
            AddForeignKey("dbo.AspNetUsers", "Gender_Id", "dbo.Genders", "Id");
            AddForeignKey("dbo.Teams", "Coach_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.AspNetUsers", "Teams_Id", "dbo.Teams", "Id");
            AddForeignKey("dbo.AspNetUsers", "Position_Id", "dbo.Positions", "Id");
        }
    }
}
