namespace BICT.Payetakht.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A003 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CarDetails", "CarYearID", "dbo.CarYears");
            DropIndex("dbo.CarDetails", new[] { "CarYearID" });
            AddColumn("dbo.CarDetails", "CarModelID", c => c.Int(nullable: false));
            AddColumn("dbo.CarModels", "CarDetailID", c => c.Int(nullable: false));
            CreateIndex("dbo.CarDetails", "CarModelID");
            AddForeignKey("dbo.CarDetails", "CarModelID", "dbo.CarModels", "ID");
            DropColumn("dbo.CarDetails", "CarYearID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CarDetails", "CarYearID", c => c.Int(nullable: false));
            DropForeignKey("dbo.CarDetails", "CarModelID", "dbo.CarModels");
            DropIndex("dbo.CarDetails", new[] { "CarModelID" });
            DropColumn("dbo.CarModels", "CarDetailID");
            DropColumn("dbo.CarDetails", "CarModelID");
            CreateIndex("dbo.CarDetails", "CarYearID");
            AddForeignKey("dbo.CarDetails", "CarYearID", "dbo.CarYears", "ID");
        }
    }
}
