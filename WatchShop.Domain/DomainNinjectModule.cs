using Ninject.Extensions.Conventions;
using Ninject.Modules;
using Ninject.Web.Common;
using WatchShop.Domain.Accounts;
using WatchShop.Domain.Accounts.Extensibility;
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
            Kernel.Bind(r => r.FromThisAssembly()
            .IncludingNonePublicTypes()
            .Select(t => t.Name.EndsWith("Repository"))
            .BindAllInterfaces());

            Bind<IShopDataContext>().To<ShopDataContext>();

            Bind<IShopDbContext>().To<ShopDbContext>().InRequestScope();

            Bind<IAccount>().To<Account>();
            Bind<ICatalog>().To<Catalog>();
            Bind<ITokenIdentifier>().To<TokenIdentifier>();
            Bind<ITokenGenerator>().To<TokenGenerator>();

            Bind<ICheckoutProcessor>().To<CheckoutProcessor>();
        }
    }
}