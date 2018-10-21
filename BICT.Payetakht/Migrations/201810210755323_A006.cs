namespace BICT.Payetakht.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A006 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Audits",
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
                        IsRead = c.Boolean(nullable: false),
                        IsDone = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CarDetails", t => t.CarDetailID)
                .ForeignKey("dbo.CarModels", t => t.CarModelID)
                .ForeignKey("dbo.CarManufacturers", t => t.CarManufactureID)
                .ForeignKey("dbo.CarYears", t => t.CarYearID)
                .Index(t => t.CarManufactureID)
                .Index(t => t.CarModelID)
                .Index(t => t.CarYearID)
                .Index(t => t.CarDetailID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Audits", "CarYearID", "dbo.CarYears");
            DropForeignKey("dbo.Audits", "CarManufactureID", "dbo.CarManufacturers");
            DropForeignKey("dbo.Audits", "CarModelID", "dbo.CarModels");
            DropForeignKey("dbo.Audits", "CarDetailID", "dbo.CarDetails");
            DropIndex("dbo.Audits", new[] { "CarDetailID" });
            DropIndex("dbo.Audits", new[] { "CarYearID" });
            DropIndex("dbo.Audits", new[] { "CarModelID" });
            DropIndex("dbo.Audits", new[] { "CarManufactureID" });
            DropTable("dbo.Audits");
        }
    }
}
