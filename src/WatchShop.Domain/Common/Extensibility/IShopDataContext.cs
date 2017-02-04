using WatchShop.Domain.Carts.Extensibility;
using WatchShop.Domain.Catalog.Extensibility;
using WatchShop.Domain.Customers.Extensibility;
using WatchShop.Domain.Database;

namespace WatchShop.Domain.Common.Extensibility
{
    public interface IShopDataContext : ISaveContext
    {
        ICustomerRepository Customers { get; }

        IProductRepository Products { get; }

        IOrderRepository Orders { get; }

        ICartRepository Carts { get; }
    }
}