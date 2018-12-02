namespace BICT.Payetakht.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A022 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 4000),
                        Name = c.String(nullable: false, maxLength: 255),
                        Email = c.String(maxLength: 255),
                        Phone = c.String(maxLength: 255),
                        CreateDateTime = c.DateTime(nullable: false),
                        IsConfirm = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Comments");
        }
    }
}
