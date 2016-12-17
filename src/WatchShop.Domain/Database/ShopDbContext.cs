using System.Data.Entity;
using WatchShop.Domain.Database.Model;

namespace WatchShop.Domain.Database
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext() : base("name=ShopDbContext")
        {
        }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Order> Orders { get; set; }

        public IDbSet<OrderProduct> OrderProducts { get; set; }
    }
}