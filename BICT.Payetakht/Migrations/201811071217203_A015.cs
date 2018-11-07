namespace BICT.Payetakht.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A015 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inspections",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AuditID = c.Int(nullable: false),
                        Description = c.String(maxLength: 1000),
                        Color = c.String(maxLength: 50),
                        ColorType = c.String(maxLength: 50),
                        GearBoxNumner = c.Int(nullable: false),
                        GearBoxType = c.String(maxLength: 50),
                        EngineVolume = c.Int(nullable: false),
                        CylinderNumber = c.Int(nullable: false),
                        FuelType = c.String(maxLength: 50),
                        Roof = c.String(maxLength: 50),
                        Trunk = c.String(maxLength: 50),
                        Hood = c.String(maxLength: 50),
                        DoorRightFront = c.String(maxLength: 50),
                        DoorLeftFront = c.String(maxLength: 50),
                        DoorRightRear = c.String(maxLength: 50),
                        DoorLeftRear = c.String(maxLength: 50),
                        PillarRightFront = c.String(maxLength: 50),
                        PillarLeftFront = c.String(maxLength: 50),
                        PillarRightRear = c.String(maxLength: 50),
                        PillarLeftRear = c.String(maxLength: 50),
                        FenderRightFront = c.String(maxLength: 50),
                        FenderLeftFront = c.String(maxLength: 50),
                        FenderRightRear = c.String(maxLength: 50),
                        FenderLeftRear = c.String(maxLength: 50),
                        PedalRight = c.String(maxLength: 50),
                        PedalLeft = c.String(maxLength: 50),
                        ChassisFront = c.String(maxLength: 50),
                        ChassisRear = c.String(maxLength: 50),
                        TireRightFront = c.Int(nullable: false),
                        TireLeftFront = c.Int(nullable: false),
                        TireRightRear = c.Int(nullable: false),
                        TireLeftRear = c.Int(nullable: false),
                        TireSpare = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Audits", t => t.AuditID)
                .Index(t => t.AuditID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inspections", "AuditID", "dbo.Audits");
            DropIndex("dbo.Inspections", new[] { "AuditID" });
            DropTable("dbo.Inspections");
        }
    }
}
