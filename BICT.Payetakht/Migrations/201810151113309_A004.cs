namespace BICT.Payetakht.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A004 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarModelYearDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CarModelID = c.Int(nullable: false),
                        CarYearID = c.Int(nullable: false),
                        CarDetailID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CarYears", t => t.CarYearID)
                .ForeignKey("dbo.CarModels", t => t.CarModelID)
                .ForeignKey("dbo.CarDetails", t => t.CarDetailID)
                .Index(t => t.CarModelID)
                .Index(t => t.CarYearID)
                .Index(t => t.CarDetailID);
            
            DropColumn("dbo.CarModels", "CarDetailID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CarModels", "CarDetailID", c => c.Int(nullable: false));
            DropForeignKey("dbo.CarModelYearDetails", "CarDetailID", "dbo.CarDetails");
            DropForeignKey("dbo.CarModelYearDetails", "CarModelID", "dbo.CarModels");
            DropForeignKey("dbo.CarModelYearDetails", "CarYearID", "dbo.CarYears");
            DropIndex("dbo.CarModelYearDetails", new[] { "CarDetailID" });
            DropIndex("dbo.CarModelYearDetails", new[] { "CarYearID" });
            DropIndex("dbo.CarModelYearDetails", new[] { "CarModelID" });
            DropTable("dbo.CarModelYearDetails");
        }
    }
}
