namespace BICT.Payetakht.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A021 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Audits", "FirstName", c => c.String(maxLength: 255));
            AlterColumn("dbo.Audits", "LastName", c => c.String(maxLength: 255));
            AlterColumn("dbo.Audits", "Email", c => c.String(maxLength: 255));
            AlterColumn("dbo.Audits", "Phone", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Audits", "Phone", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Audits", "Email", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Audits", "LastName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Audits", "FirstName", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
