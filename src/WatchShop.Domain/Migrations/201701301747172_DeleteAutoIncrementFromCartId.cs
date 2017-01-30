using System.Data.Entity.Migrations;

namespace WatchShop.Domain.Migrations
{
    public partial class DeleteAutoIncrementFromCartId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cart", "Id", "dbo.Customer");
            DropForeignKey("dbo.CartItem", "CartId", "dbo.Cart");
            DropIndex("dbo.Cart", new[] { "Id" });
            AddColumn("dbo.Cart", "IdNew", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Cart");
            DropColumn("dbo.Cart", "Id");
            RenameColumn("dbo.Cart", "IdNew", "Id");
            CreateIndex("dbo.Cart", new[] { "Id" });
            AddPrimaryKey("dbo.Cart", "Id");
            AddForeignKey("dbo.Cart", "Id", "dbo.Customer");
            AddForeignKey("dbo.CartItem", "CartId", "dbo.Cart");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Cart", "Id", "dbo.Customer");
            DropForeignKey("dbo.CartItem", "CartId", "dbo.Cart");
            DropIndex("dbo.Cart", new[] { "Id" });
            AddColumn("dbo.Cart", "IdNew", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Cart");
            DropColumn("dbo.Cart", "Id");
            RenameColumn("dbo.Cart", "IdNew", "Id");
            CreateIndex("dbo.Cart", new[] { "Id" });
            AddPrimaryKey("dbo.Cart", "Id");
            AddForeignKey("dbo.Cart", "Id", "dbo.Customer");
            AddForeignKey("dbo.CartItem", "CartId", "dbo.Cart");
        }
    }
}