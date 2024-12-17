namespace EnvanterMVC.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teslims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tarih = c.DateTime(nullable: false),
                        TeslimEden = c.String(),
                        TeslimAlan = c.String(),
                        TeslimEdilenDepartman = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UrunBilgis",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tur = c.String(),
                        Marka = c.String(),
                        Model = c.String(),
                        SeriNo = c.String(),
                        IMEI = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.UrunBilgis");
            DropTable("dbo.Teslims");
        }
    }
}
