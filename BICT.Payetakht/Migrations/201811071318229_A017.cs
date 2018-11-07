namespace BICT.Payetakht.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A017 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inspections", "BodyType", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inspections", "BodyType");
        }
    }
}
