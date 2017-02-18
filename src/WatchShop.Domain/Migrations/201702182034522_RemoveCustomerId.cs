using System.Data.Entity.Migrations;

namespace WatchShop.Domain.Migrations
{
    public partial class RemoveCustomerId : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Identity", "CustomerId");
            DropColumn("dbo.Token", "CustomerId");
        }

        public override void Down()
        {
            AddColumn("dbo.Token", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Identity", "CustomerId", c => c.Int(nullable: false));
        }
    }
}