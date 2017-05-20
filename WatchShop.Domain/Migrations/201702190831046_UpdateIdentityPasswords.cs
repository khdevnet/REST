using System.Data.Entity.Migrations;
using System.Linq;
using WatchShop.Domain.Common;
using WatchShop.Domain.Database;
using WatchShop.Domain.Identities.Extensibility.Entities;

namespace WatchShop.Domain.Migrations
{
    public partial class UpdateIdentityPasswords : DbMigration
    {
        private const string TrialPassword = "123456";

        public override void Up()
        {
            using (var context = new ShopDbContext())
            {
                var customerIds = context.Customers.Select(customer => customer.Id).ToList();

                foreach (var customerId in customerIds)
                {
                    var identity = context.Identities.FirstOrDefault(entity => entity.Id == customerId);
                    if (identity == null)
                    {
                        context.Identities.Add(new Identity
                        {
                            Id = customerId,
                            Password = Cryptographer.Encode(TrialPassword)
                        });
                    }
                }
                context.SaveChanges();
            }
        }

        public override void Down()
        {
            Sql("DELETE FROM [dbo].[Identity]");
        }
    }
}