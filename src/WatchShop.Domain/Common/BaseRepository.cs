using WatchShop.Domain.Database;

namespace WatchShop.Domain.Common
{
    internal abstract class RepositoryBase
    {
        protected readonly IShopDbContext context;

        public RepositoryBase(IShopDbContext context)
        {
            this.context = context;
        }
    }
}