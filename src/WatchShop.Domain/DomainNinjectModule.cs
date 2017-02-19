using Ninject.Modules;
using WatchShop.Domain.Accounts;
using WatchShop.Domain.Accounts.Extensibility;
using WatchShop.Domain.Carts;
using WatchShop.Domain.Carts.Extensibility;
using WatchShop.Domain.Catalogs;
using WatchShop.Domain.Catalogs.Extensibility;
using WatchShop.Domain.Checkout;
using WatchShop.Domain.Common;
using WatchShop.Domain.Common.Extensibility;
using WatchShop.Domain.Database;
using WatchShop.Domain.Identities;
using WatchShop.Domain.Identities.Extensibility;

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
            Bind<IIdentityRepository>().To<IdentityRepository>();
            Bind<ITokenRepository>().To<TokenRepository>();
            Bind<IShopDataContext>().To<ShopDataContext>();

            Bind<IShopDbContext>().To<ShopDbContext>().InSingletonScope();

            Bind<IAccount>().To<Account>();
            Bind<ICatalog>().To<Catalog>();
            Bind<ITokenIdentifier>().To<TokenIdentifier>();
            Bind<ITokenGenerator>().To<TokenGenerator>();

            Bind<ICheckoutProcessor>().To<CheckoutProcessor>();
        }
    }
}