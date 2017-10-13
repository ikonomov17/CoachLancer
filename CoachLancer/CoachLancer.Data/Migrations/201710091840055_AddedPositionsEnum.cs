namespace CoachLancer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPositionsEnum : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "PriceForHourTraining", c => c.Double());
            AddColumn("dbo.AspNetUsers", "Experience", c => c.Int());
            AddColumn("dbo.AspNetUsers", "Position_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "Position_Id");
            AddForeignKey("dbo.AspNetUsers", "Position_Id", "dbo.Positions", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "Position_Id", "dbo.Positions");
            DropIndex("dbo.AspNetUsers", new[] { "Position_Id" });
            DropColumn("dbo.AspNetUsers", "Position_Id");
            DropColumn("dbo.AspNetUsers", "Experience");
            DropColumn("dbo.AspNetUsers", "PriceForHourTraining");
            DropTable("dbo.Positions");
        }
    }
}
