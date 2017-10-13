namespace CoachLancer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedRatings : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "Rating_Id", "dbo.Ratings");
            DropIndex("dbo.AspNetUsers", new[] { "Rating_Id" });
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "StartedTraining", c => c.DateTime());
            DropColumn("dbo.AspNetUsers", "Rating_Id");
            DropTable("dbo.Ratings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "Rating_Id", c => c.Int());
            DropColumn("dbo.AspNetUsers", "StartedTraining");
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            CreateIndex("dbo.AspNetUsers", "Rating_Id");
            AddForeignKey("dbo.AspNetUsers", "Rating_Id", "dbo.Ratings", "Id");
        }
    }
}
