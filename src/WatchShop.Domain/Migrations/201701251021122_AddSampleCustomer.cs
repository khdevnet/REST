using System.Data.Entity.Migrations;

namespace WatchShop.Domain.Migrations
{
    public partial class AddSampleCustomer : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[Customer] ([Name], [Email], [Phone], [Address])
                  VALUES ('anton', 'anton@gmail.com', '555-665-34', 'adrress')");
        }

        public override void Down()
        {
            Sql(@"DELETE FROM [dbo].[Customer] WHERE Email='anton@gmail.com'");
        }
    }
}