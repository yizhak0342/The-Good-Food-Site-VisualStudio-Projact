namespace Final_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactUs", "TimeToSendAMessage", c => c.DateTime(nullable: false));
            DropColumn("dbo.ContactUs", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactUs", "MyProperty", c => c.DateTime(nullable: false));
            DropColumn("dbo.ContactUs", "TimeToSendAMessage");
        }
    }
}
