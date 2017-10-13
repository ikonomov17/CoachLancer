namespace CoachLancer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedCoachAndPlayerModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DateOfBirth", c => c.DateTime());
            AddColumn("dbo.AspNetUsers", "PricePerHourTraining", c => c.Double());
            AddColumn("dbo.AspNetUsers", "StartedCoaching", c => c.DateTime());
            DropColumn("dbo.AspNetUsers", "Age");
            DropColumn("dbo.AspNetUsers", "PriceForHourTraining");
            DropColumn("dbo.AspNetUsers", "Experience");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "Experience", c => c.Int());
            AddColumn("dbo.AspNetUsers", "PriceForHourTraining", c => c.Double());
            AddColumn("dbo.AspNetUsers", "Age", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "StartedCoaching");
            DropColumn("dbo.AspNetUsers", "PricePerHourTraining");
            DropColumn("dbo.AspNetUsers", "DateOfBirth");
        }
    }
}
