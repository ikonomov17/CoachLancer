namespace CoachLancer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedGenderEnum : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamSize = c.Int(nullable: false),
                        Coach_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Coach_Id)
                .Index(t => t.Coach_Id);
            
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Location", c => c.String());
            AddColumn("dbo.AspNetUsers", "Nationality", c => c.String());
            AddColumn("dbo.AspNetUsers", "AboutMe", c => c.String());
            AddColumn("dbo.AspNetUsers", "Height", c => c.Double());
            AddColumn("dbo.AspNetUsers", "Weight", c => c.Double());
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.AspNetUsers", "Rating_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Teams_Id", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Gender_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Rating_Id");
            CreateIndex("dbo.AspNetUsers", "Teams_Id");
            CreateIndex("dbo.AspNetUsers", "Gender_Id");
            AddForeignKey("dbo.AspNetUsers", "Rating_Id", "dbo.Ratings", "Id");
            AddForeignKey("dbo.AspNetUsers", "Teams_Id", "dbo.Teams", "Id");
            AddForeignKey("dbo.AspNetUsers", "Gender_Id", "dbo.Genders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Gender_Id", "dbo.Genders");
            DropForeignKey("dbo.Teams", "Coach_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Teams_Id", "dbo.Teams");
            DropForeignKey("dbo.AspNetUsers", "Rating_Id", "dbo.Ratings");
            DropIndex("dbo.Teams", new[] { "Coach_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Gender_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Teams_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Rating_Id" });
            DropColumn("dbo.AspNetUsers", "Gender_Id");
            DropColumn("dbo.AspNetUsers", "Teams_Id");
            DropColumn("dbo.AspNetUsers", "Rating_Id");
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.AspNetUsers", "Weight");
            DropColumn("dbo.AspNetUsers", "Height");
            DropColumn("dbo.AspNetUsers", "AboutMe");
            DropColumn("dbo.AspNetUsers", "Nationality");
            DropColumn("dbo.AspNetUsers", "Location");
            DropColumn("dbo.AspNetUsers", "Age");
            DropTable("dbo.Teams");
            DropTable("dbo.Ratings");
            DropTable("dbo.Genders");
        }
    }
}
