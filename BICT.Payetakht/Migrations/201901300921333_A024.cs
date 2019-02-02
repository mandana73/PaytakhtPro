namespace BICT.Payetakht.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class A024 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Inspections", "DefaultPicture");
        }

        public override void Down()
        {
            AddColumn("dbo.Inspections", "DefaultPicture", c => c.String(maxLength: 255));
        }
    }
}
