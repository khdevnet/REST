using System.Data.Entity.Migrations;

namespace WatchShop.Domain.Migrations
{
    public partial class AddCustomerCartReference : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Cart");
            AlterColumn("dbo.Cart", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Cart", "Id");
            CreateIndex("dbo.Cart", "Id");
            AddForeignKey("dbo.Cart", "Id", "dbo.Customer", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cart", "Id", "dbo.Customer");
            DropIndex("dbo.Cart", new[] { "Id" });
            DropPrimaryKey("dbo.Cart");
            AlterColumn("dbo.Cart", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Cart", "Id");
        }
    }
}