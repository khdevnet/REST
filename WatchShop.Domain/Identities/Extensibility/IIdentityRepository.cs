using WatchShop.Domain.Identities.Extensibility.Entities;

namespace WatchShop.Domain.Identities.Extensibility
{
    public interface IIdentityRepository
    {
        void Add(Identity identity);
    }
}