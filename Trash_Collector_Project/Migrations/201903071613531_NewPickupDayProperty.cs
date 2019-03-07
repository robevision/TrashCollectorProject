namespace Trash_Collector_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewPickupDayProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "PickupDay", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "PickupDay");
        }
    }
}
