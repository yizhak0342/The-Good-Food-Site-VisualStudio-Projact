namespace Final_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpDateReviewModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "RestaurantName", c => c.String());
            AddColumn("dbo.Reviews", "Category", c => c.String());
            AddColumn("dbo.Reviews", "Area", c => c.String());
            DropColumn("dbo.Reviews", "RestaurantId");
            DropColumn("dbo.Reviews", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reviews", "UserId", c => c.Long(nullable: false));
            AddColumn("dbo.Reviews", "RestaurantId", c => c.Long(nullable: false));
            DropColumn("dbo.Reviews", "Area");
            DropColumn("dbo.Reviews", "Category");
            DropColumn("dbo.Reviews", "RestaurantName");
        }
    }
}
