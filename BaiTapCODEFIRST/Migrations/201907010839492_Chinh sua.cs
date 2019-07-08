namespace BaiTapCODEFIRST.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Chinhsua : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.OrderItem", "Username", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.OrderItem", "Username", c => c.String());
        }
    }
}
