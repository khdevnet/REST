using System.Data.Entity.Migrations;

namespace WatchShop.Domain.Migrations
{
    public partial class AddCarts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartItem",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    ProductId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Product", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);

            CreateTable(
                "dbo.Cart",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CustomerId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);
        }

        public override void Down()
        {
            DropForeignKey("dbo.CartItem", "ProductId", "dbo.Product");
            DropIndex("dbo.CartItem", new[] { "ProductId" });
            DropTable("dbo.Cart");
            DropTable("dbo.CartItem");
        }
    }
}