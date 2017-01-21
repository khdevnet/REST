using System.Data.Entity.Migrations;

namespace WatchShop.Domain.Migrations
{
    public partial class AddCartCartItemReference : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartItem", "CartId", c => c.Int(nullable: false));
            CreateIndex("dbo.CartItem", "CartId");
            AddForeignKey("dbo.CartItem", "CartId", "dbo.Cart", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItem", "CartId", "dbo.Cart");
            DropIndex("dbo.CartItem", new[] { "CartId" });
            DropColumn("dbo.CartItem", "CartId");
        }
    }
}