using System.Data.Entity.Migrations;

namespace WatchShop.Domain.Migrations
{
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 256),
                    Email = c.String(nullable: false, maxLength: 256),
                    Phone = c.String(nullable: false, maxLength: 256),
                    Address = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Order",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Total = c.Decimal(nullable: false, precision: 9, scale: 2),
                    Customer_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.Customer_Id)
                .Index(t => t.Customer_Id);

            CreateTable(
                "dbo.OrderProduct",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    OrderId = c.Int(nullable: false),
                    ProductId = c.Int(nullable: false),
                    Name = c.String(nullable: false, maxLength: 256),
                    Price = c.Decimal(nullable: false, precision: 9, scale: 2),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);

            CreateTable(
                "dbo.Product",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 256),
                    Price = c.Decimal(nullable: false, precision: 9, scale: 2),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Order", "Customer_Id", "dbo.Customer");
            DropForeignKey("dbo.OrderProduct", "ProductId", "dbo.Product");
            DropForeignKey("dbo.OrderProduct", "OrderId", "dbo.Order");
            DropIndex("dbo.OrderProduct", new[] { "ProductId" });
            DropIndex("dbo.OrderProduct", new[] { "OrderId" });
            DropIndex("dbo.Order", new[] { "Customer_Id" });
            DropTable("dbo.Product");
            DropTable("dbo.OrderProduct");
            DropTable("dbo.Order");
            DropTable("dbo.Customer");
        }
    }
}
