namespace BICT.Payetakht.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A013 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Audits", "PaymentTypeID", c => c.Int());
            AddColumn("dbo.AuditTemps", "PaymentTypeID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AuditTemps", "PaymentTypeID");
            DropColumn("dbo.Audits", "PaymentTypeID");
        }
    }
}
