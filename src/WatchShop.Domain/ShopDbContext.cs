using System.Data.Entity;
using WatchShop.Domain.Customers;
using WatchShop.Domain.Orders;
using WatchShop.Domain.Products;

namespace WatchShop.Domain
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext() : base("name=ShopDbContext")
        {
        }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Order> Orders { get; set; }

        public IDbSet<Customer> Customers { get; set; }

        public IDbSet<OrderProduct> OrderProducts { get; set; }
    }
}