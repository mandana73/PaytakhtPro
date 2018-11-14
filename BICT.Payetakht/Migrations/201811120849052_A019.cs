namespace BICT.Payetakht.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A019 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PictureOfSlides",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        PicturePath = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PictureOfSlides");
        }
    }
}
