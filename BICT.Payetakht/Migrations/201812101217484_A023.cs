namespace BICT.Payetakht.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A023 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inspections", "DefaultPicture", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inspections", "DefaultPicture");
        }
    }
}
