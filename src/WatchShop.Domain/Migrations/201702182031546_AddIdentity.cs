using System.Data.Entity.Migrations;

namespace WatchShop.Domain.Migrations
{
    public partial class AddIdentity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Identity",
                c => new
                {
                    Id = c.Int(nullable: false),
                    CustomerId = c.Int(nullable: false),
                    Password = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.Token",
                c => new
                {
                    Id = c.Int(nullable: false),
                    CustomerId = c.Int(nullable: false),
                    Value = c.String(nullable: false, maxLength: 256),
                    GenerationTime = c.DateTime(nullable: false),
                    ExpiredTime = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customer", t => t.Id)
                .Index(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Token", "Id", "dbo.Customer");
            DropForeignKey("dbo.Identity", "Id", "dbo.Customer");
            DropIndex("dbo.Token", new[] { "Id" });
            DropIndex("dbo.Identity", new[] { "Id" });
            DropTable("dbo.Token");
            DropTable("dbo.Identity");
        }
    }
}