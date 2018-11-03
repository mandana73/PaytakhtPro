namespace BICT.Payetakht.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A009 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "Summary", c => c.String(nullable: false, maxLength: 1000));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "Summary");
        }
    }
}
