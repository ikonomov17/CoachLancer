namespace CoachLancer.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixCreatedOnNotToBeNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "CreatedOn", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Groups", "CreatedOn", c => c.DateTime(nullable: false));
            DropColumn("dbo.Groups", "DateOfBirth");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groups", "DateOfBirth", c => c.DateTime());
            AlterColumn("dbo.Groups", "CreatedOn", c => c.DateTime());
            AlterColumn("dbo.AspNetUsers", "CreatedOn", c => c.DateTime());
        }
    }
}
