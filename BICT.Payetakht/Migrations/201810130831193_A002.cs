namespace BICT.Payetakht.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A002 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CarYears", "CarModels_ID", "dbo.CarModels");
            DropIndex("dbo.CarYears", new[] { "CarModels_ID" });
            DropColumn("dbo.CarYears", "CarModels_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CarYears", "CarModels_ID", c => c.Int());
            CreateIndex("dbo.CarYears", "CarModels_ID");
            AddForeignKey("dbo.CarYears", "CarModels_ID", "dbo.CarModels", "ID");
        }
    }
}
