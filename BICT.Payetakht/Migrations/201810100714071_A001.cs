namespace BICT.Payetakht.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class A001 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CarDetails",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CarYearID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CarYears", t => t.CarYearID)
                .Index(t => t.CarYearID);
            
            CreateTable(
                "dbo.CarYears",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CarModelID = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        CarModels_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CarModels", t => t.CarModelID)
                .ForeignKey("dbo.CarModels", t => t.CarModels_ID)
                .Index(t => t.CarModelID)
                .Index(t => t.CarModels_ID);
            
            CreateTable(
                "dbo.CarModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CarManufacturerID = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.CarManufacturers", t => t.CarManufacturerID)
                .Index(t => t.CarManufacturerID);
            
            CreateTable(
                "dbo.CarManufacturers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.IdentityUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.IdentityUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.IdentityUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.IdentityUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.IdentityUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.CarYears", "CarModels_ID", "dbo.CarModels");
            DropForeignKey("dbo.CarYears", "CarModelID", "dbo.CarModels");
            DropForeignKey("dbo.CarModels", "CarManufacturerID", "dbo.CarManufacturers");
            DropForeignKey("dbo.CarDetails", "CarYearID", "dbo.CarYears");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.CarModels", new[] { "CarManufacturerID" });
            DropIndex("dbo.CarYears", new[] { "CarModels_ID" });
            DropIndex("dbo.CarYears", new[] { "CarModelID" });
            DropIndex("dbo.CarDetails", new[] { "CarYearID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.IdentityUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Cities");
            DropTable("dbo.CarManufacturers");
            DropTable("dbo.CarModels");
            DropTable("dbo.CarYears");
            DropTable("dbo.CarDetails");
        }
    }
}
