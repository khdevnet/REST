using System.Data.Entity.Migrations;

namespace WatchShop.Domain.Migrations
{
    public partial class UpdateCustomerToCartReference : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE Cart DROP CONSTRAINT [FK_dbo.Cart_dbo.Customer_Id]");
            Sql("ALTER TABLE Cart ADD CONSTRAINT[FK_dbo.Cart_dbo.Customer_Id] FOREIGN KEY(CustomerId) REFERENCES Customer(Id) ON DELETE CASCADE ON UPDATE CASCADE");
        }

        public override void Down()
        {
            Sql("ALTER TABLE Cart DROP CONSTRAINT [FK_dbo.Cart_dbo.Customer_Id]");
            Sql("ALTER TABLE Cart ADD CONSTRAINT [FK_dbo.Cart_dbo.Customer_Id] FOREIGN KEY(Id) REFERENCES Customer(Id)");
        }
    }
}