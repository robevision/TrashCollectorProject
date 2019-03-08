namespace Trash_Collector_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddressUnitNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "Unit", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "Unit", c => c.Int(nullable: false));
        }
    }
}
