using Ninject.Modules;
using WatchShop.Domain.Catalog;
using WatchShop.Domain.Customers;
using WatchShop.Domain.Carts;

namespace WatchShop.Domain
{
    public class DomainNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductRepository>().To<ProductRepository>();
            Bind<ICartRepository>().To<CartRepository>();

            Bind<ICustomerRepository>().To<CustomerRepository>();
            Bind<ICustomerRegistration>().To<CustomerRegistration>();
        }
    }
}