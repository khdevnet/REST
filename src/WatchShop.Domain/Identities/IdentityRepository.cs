using WatchShop.Domain.Common;
using WatchShop.Domain.Database;
using WatchShop.Domain.Identities.Extensibility;
using WatchShop.Domain.Identities.Extensibility.Entities;

namespace WatchShop.Domain.Identities
{
    internal class IdentityRepository : RepositoryBase, IIdentityRepository
    {
        public IdentityRepository(IShopDbContext context) : base(context)
        {
        }

        public void Add(Identity identity)
        {
            context.Identities.Add(identity);
        }
    }
}