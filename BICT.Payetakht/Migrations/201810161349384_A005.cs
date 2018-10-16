namespace BICT.Payetakht.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A005 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarModelYearDetails", "Price", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CarModelYearDetails", "Price");
        }
    }
}
