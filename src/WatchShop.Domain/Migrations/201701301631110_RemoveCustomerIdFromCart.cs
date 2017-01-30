using System.Data.Entity.Migrations;

namespace WatchShop.Domain.Migrations
{
    public partial class RemoveCustomerIdFromCart : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cart", "CustomerId");
        }

        public override void Down()
        {
            AddColumn("dbo.Cart", "CustomerId", c => c.Int(nullable: false));
        }
    }
}