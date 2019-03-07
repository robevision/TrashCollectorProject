namespace Trash_Collector_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PickupNowNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Pickup", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "Pickup", c => c.Boolean(nullable: false));
        }
    }
}
