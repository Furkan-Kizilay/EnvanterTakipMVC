namespace EnvanterMVC.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateSchema : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "IMEI", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "IMEI", c => c.Int(nullable: false));
        }
    }
}
