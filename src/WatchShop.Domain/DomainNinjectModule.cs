using Ninject.Modules;
using WatchShop.Domain.Catalog;
using WatchShop.Domain.Customers;

namespace WatchShop.Domain
{
    public class DomainNinjectModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IProductRepository>().To<ProductRepository>();
            Bind<ICartRepository>().To<CartRepository>();
        }
    }
}