namespace BICT.Payetakht.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A007 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MetaKeyWords",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MetaKeyWords");
        }
    }
}
