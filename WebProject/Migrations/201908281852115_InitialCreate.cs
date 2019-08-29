namespace WebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        CardId = c.Int(nullable: false, identity: true),
                        CardNumber = c.Int(nullable: false),
                        CVCCode = c.Int(nullable: false),
                        DateTo = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.CardId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        CardId = c.Int(nullable: false),
                        PurchaseInfoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Cards", t => t.CardId, cascadeDelete: true)
                .ForeignKey("dbo.PurchaseInfoes", t => t.PurchaseInfoId, cascadeDelete: true)
                .Index(t => t.CardId)
                .Index(t => t.PurchaseInfoId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                        Description = c.String(nullable: false, maxLength: 100),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.PurchaseInfoes",
                c => new
                    {
                        PurchaseInfoId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 70),
                        CountryId = c.Int(nullable: false),
                        Adress = c.String(nullable: false, maxLength: 70),
                        Area = c.String(nullable: false, maxLength: 70),
                        CityId = c.Int(nullable: false),
                        Index = c.Int(nullable: false),
                        Phone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseInfoId)
                .ForeignKey("dbo.Cities", t => t.CityId, cascadeDelete: true)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .Index(t => t.CountryId)
                .Index(t => t.CityId);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        CityId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.CityId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        SellerId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 70),
                    })
                .PrimaryKey(t => t.SellerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "PurchaseInfoId", "dbo.PurchaseInfoes");
            DropForeignKey("dbo.PurchaseInfoes", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.PurchaseInfoes", "CityId", "dbo.Cities");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Users", "CardId", "dbo.Cards");
            DropIndex("dbo.PurchaseInfoes", new[] { "CityId" });
            DropIndex("dbo.PurchaseInfoes", new[] { "CountryId" });
            DropIndex("dbo.Orders", new[] { "ProductId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Users", new[] { "PurchaseInfoId" });
            DropIndex("dbo.Users", new[] { "CardId" });
            DropTable("dbo.Sellers");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.PurchaseInfoes");
            DropTable("dbo.Products");
            DropTable("dbo.Orders");
            DropTable("dbo.Users");
            DropTable("dbo.Cards");
        }
    }
}
