namespace Trash_Collector_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeTypesNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "StartBreak", c => c.DateTime());
            AlterColumn("dbo.Customers", "EndBreak", c => c.DateTime());
            AlterColumn("dbo.Customers", "ExtraPickup", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "ExtraPickup", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "EndBreak", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "StartBreak", c => c.DateTime(nullable: false));
        }
    }
}
