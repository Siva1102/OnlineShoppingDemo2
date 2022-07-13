namespace OnlineShoppingDemo2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class load : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CateId = c.Int(nullable: false, identity: true),
                        CateName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.CateId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ImageUrl = c.String(),
                        ImageUrl1 = c.String(),
                        ImageUrl2 = c.String(),
                        ImageUrl3 = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CateId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CateId, cascadeDelete: true)
                .Index(t => t.CateId);
            
            CreateTable(
                "dbo.Registers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CateId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "CateId" });
            DropTable("dbo.Registers");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
