namespace WebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "CardId", "dbo.Cards");
            DropForeignKey("dbo.Users", "PurchaseInfoId", "dbo.PurchaseInfoes");
            DropIndex("dbo.Users", new[] { "CardId" });
            DropIndex("dbo.Users", new[] { "PurchaseInfoId" });
            AddColumn("dbo.Orders", "CardId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "PurchaseInfoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "CardId");
            CreateIndex("dbo.Orders", "PurchaseInfoId");
            AddForeignKey("dbo.Orders", "CardId", "dbo.Cards", "CardId", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "PurchaseInfoId", "dbo.PurchaseInfoes", "PurchaseInfoId", cascadeDelete: true);
            DropColumn("dbo.Users", "CardId");
            DropColumn("dbo.Users", "PurchaseInfoId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "PurchaseInfoId", c => c.Int(nullable: false));
            AddColumn("dbo.Users", "CardId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "PurchaseInfoId", "dbo.PurchaseInfoes");
            DropForeignKey("dbo.Orders", "CardId", "dbo.Cards");
            DropIndex("dbo.Orders", new[] { "PurchaseInfoId" });
            DropIndex("dbo.Orders", new[] { "CardId" });
            DropColumn("dbo.Orders", "PurchaseInfoId");
            DropColumn("dbo.Orders", "CardId");
            CreateIndex("dbo.Users", "PurchaseInfoId");
            CreateIndex("dbo.Users", "CardId");
            AddForeignKey("dbo.Users", "PurchaseInfoId", "dbo.PurchaseInfoes", "PurchaseInfoId", cascadeDelete: true);
            AddForeignKey("dbo.Users", "CardId", "dbo.Cards", "CardId", cascadeDelete: true);
        }
    }
}
