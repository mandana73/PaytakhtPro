namespace BICT.Payetakht.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A011 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Audits", "PaymentDate", c => c.DateTime());
            AddColumn("dbo.Audits", "ReferID", c => c.Long());
            AddColumn("dbo.Audits", "Authority", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Audits", "Authority");
            DropColumn("dbo.Audits", "ReferID");
            DropColumn("dbo.Audits", "PaymentDate");
        }
    }
}
