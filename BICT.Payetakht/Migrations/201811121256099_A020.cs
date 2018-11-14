namespace BICT.Payetakht.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A020 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Readings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        Content = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Readings");
        }
    }
}
