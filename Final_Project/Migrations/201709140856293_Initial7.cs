namespace Final_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ContactUs", "TimeToSendAMessage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactUs", "TimeToSendAMessage", c => c.DateTime(nullable: false));
        }
    }
}
