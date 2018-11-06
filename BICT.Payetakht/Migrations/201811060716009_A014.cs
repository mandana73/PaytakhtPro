namespace BICT.Payetakht.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A014 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CarModelYearDetails", "ImageUrl", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CarModelYearDetails", "ImageUrl");
        }
    }
}
