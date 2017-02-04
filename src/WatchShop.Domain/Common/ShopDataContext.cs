using WatchShop.Domain.Carts.Extensibility;
using WatchShop.Domain.Catalog.Extensibility;
using WatchShop.Domain.Common.Extensibility;
using WatchShop.Domain.Customers.Extensibility;
using WatchShop.Domain.Database;

namespace WatchShop.Domain.Common
{
    internal class ShopDataContext : IShopDataContext
    {
        private readonly IShopDbContext context;

        public ShopDataContext(
            IShopDbContext context,
            ICartRepository cartRepository,
            ICustomerRepository customerRepository,
            IOrderRepository orderRepository,
            IProductRepository productRepository)
        {
            this.context = context;

            Carts = cartRepository;
            Customers = customerRepository;
            Orders = orderRepository;
            Products = productRepository;
        }

        public ICartRepository Carts { get; }

        public ICustomerRepository Customers { get; }

        public IOrderRepository Orders { get; }

        public IProductRepository Products { get; }

        public int SaveChanges()
        {
           return context.SaveChanges();
        }
    }
}