using WatchShop.Domain.Accounts.Extensibility;
using WatchShop.Domain.Carts.Extensibility;
using WatchShop.Domain.Catalogs.Extensibility;
using WatchShop.Domain.Common.Extensibility;
using WatchShop.Domain.Database;
using WatchShop.Domain.Identities.Extensibility;

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
            IProductRepository productRepository,
            IIdentityRepository identityRepository)
        {
            this.context = context;

            Carts = cartRepository;
            Customers = customerRepository;
            Orders = orderRepository;
            Products = productRepository;
            Identities = identityRepository;
        }

        public ICartRepository Carts { get; }

        public ICustomerRepository Customers { get; }

        public IOrderRepository Orders { get; }

        public IProductRepository Products { get; }

        public IIdentityRepository Identities { get; }

        public int SaveChanges()
        {
           return context.SaveChanges();
        }
    }
}