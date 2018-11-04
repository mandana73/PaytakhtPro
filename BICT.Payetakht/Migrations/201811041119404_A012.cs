namespace BICT.Payetakht.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A012 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AuditTemps", "PaymentDate", c => c.DateTime());
            AddColumn("dbo.AuditTemps", "ReferID", c => c.Long());
            AddColumn("dbo.AuditTemps", "Authority", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AuditTemps", "Authority");
            DropColumn("dbo.AuditTemps", "ReferID");
            DropColumn("dbo.AuditTemps", "PaymentDate");
        }
    }
}
