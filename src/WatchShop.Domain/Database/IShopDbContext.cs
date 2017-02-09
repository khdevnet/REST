using System.Data.Entity;
using WatchShop.Domain.Accounts.Extensibility.Entities;
using WatchShop.Domain.Carts.Extensibility.Entities;
using WatchShop.Domain.Catalogs.Extensibility.Entities;

namespace WatchShop.Domain.Database
{
    internal interface IShopDbContext
    {
        IDbSet<CartItem> CartItems { get; set; }

        IDbSet<Cart> Carts { get; set; }

        IDbSet<Customer> Customers { get; set; }

        IDbSet<OrderProduct> OrderProducts { get; set; }

        IDbSet<Order> Orders { get; set; }

        IDbSet<Product> Products { get; set; }

        int SaveChanges();
    }
}