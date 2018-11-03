namespace BICT.Payetakht.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A010 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuditTemps",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CarManufactureID = c.Int(nullable: false),
                        CarModelID = c.Int(nullable: false),
                        CarYearID = c.Int(nullable: false),
                        CarDetailID = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(nullable: false, maxLength: 255),
                        Email = c.String(nullable: false, maxLength: 255),
                        Phone = c.String(nullable: false, maxLength: 15),
                        RequestDate = c.DateTime(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CarManufacturers", t => t.CarManufactureID)
                .ForeignKey("dbo.CarModels", t => t.CarModelID)
                .ForeignKey("dbo.CarYears", t => t.CarYearID)
                .ForeignKey("dbo.CarDetails", t => t.CarDetailID)
                .Index(t => t.CarManufactureID)
                .Index(t => t.CarModelID)
                .Index(t => t.CarYearID)
                .Index(t => t.CarDetailID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuditTemps", "CarDetailID", "dbo.CarDetails");
            DropForeignKey("dbo.AuditTemps", "CarYearID", "dbo.CarYears");
            DropForeignKey("dbo.AuditTemps", "CarModelID", "dbo.CarModels");
            DropForeignKey("dbo.AuditTemps", "CarManufactureID", "dbo.CarManufacturers");
            DropIndex("dbo.AuditTemps", new[] { "CarDetailID" });
            DropIndex("dbo.AuditTemps", new[] { "CarYearID" });
            DropIndex("dbo.AuditTemps", new[] { "CarModelID" });
            DropIndex("dbo.AuditTemps", new[] { "CarManufactureID" });
            DropTable("dbo.AuditTemps");
        }
    }
}
