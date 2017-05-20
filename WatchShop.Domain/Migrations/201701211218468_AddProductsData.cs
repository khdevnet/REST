using System.Data.Entity.Migrations;

namespace WatchShop.Domain.Migrations
{
    public partial class AddProductsData : DbMigration
    {
        public override void Up()
        {
            Sql(SqlScripts.InsertProducts);
        }

        public override void Down()
        {
            Sql("Delete * From Product");
        }
    }
}