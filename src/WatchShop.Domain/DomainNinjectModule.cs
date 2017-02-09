using Ninject.Modules;
using WatchShop.Domain.Accounts;
using WatchShop.Domain.Accounts.Extensibility;
using WatchShop.Domain.Carts;
using WatchShop.Domain.Carts.Extensibility;
using WatchShop.Domain.Catalogs;
using WatchShop.Domain.Catalogs.Extensibility;
using WatchShop.Domain.Common;
using WatchShop.Domain.Common.Extensibility;
using WatchShop.Domain.Database;

namespace WatchShop.Domain
{
    public class DomainNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductRepository>().To<ProductRepository>();
            Bind<ICartRepository>().To<CartRepository>();
            Bind<ICustomerRepository>().To<CustomerRepository>();
            Bind<IOrderRepository>().To<OrderRepository>();
            Bind<IShopDataContext>().To<ShopDataContext>();

            Bind<IShopDbContext>().To<ShopDbContext>().InSingletonScope();

            Bind<IAccount>().To<Account>();
            Bind<ICatalog>().To<Catalog>();
            Bind<ICheckoutProcess>().To<CheckoutProcess>();
        }
    }
}