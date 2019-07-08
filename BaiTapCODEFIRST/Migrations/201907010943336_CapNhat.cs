namespace BaiTapCODEFIRST.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CapNhat : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderItem", "ProductName", c => c.String(nullable: false));
            AddColumn("dbo.OrderItem", "Quantity", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderItem", "Quantity");
            DropColumn("dbo.OrderItem", "ProductName");
        }
    }
}
