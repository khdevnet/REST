using Ninject.Modules;
using WatchShop.Domain.Carts;
using WatchShop.Domain.Carts.Extensibility;
using WatchShop.Domain.Catalog;
using WatchShop.Domain.Catalog.Extensibility;
using WatchShop.Domain.Common;
using WatchShop.Domain.Common.Extensibility;
using WatchShop.Domain.Customers;
using WatchShop.Domain.Customers.Extensibility;
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

            Bind<ICustomerRegistration>().To<CustomerRegistration>();
            Bind<ICatalogAdministration>().To<CatalogAdministration>();
            Bind<ICheckoutProcess>().To<CheckoutProcess>();
        }
    }
}