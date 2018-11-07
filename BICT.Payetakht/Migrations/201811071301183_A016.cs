namespace BICT.Payetakht.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A016 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inspections", "Usage", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inspections", "Usage");
        }
    }
}
