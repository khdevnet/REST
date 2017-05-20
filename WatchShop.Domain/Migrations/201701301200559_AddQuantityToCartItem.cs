using System.Data.Entity.Migrations;

namespace WatchShop.Domain.Migrations
{
    public partial class AddQuantityToCartItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartItem", "Quantity", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.CartItem", "Quantity");
        }
    }
}