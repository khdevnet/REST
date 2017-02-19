using WatchShop.Domain.Identities.Extensibility.Entities;

namespace WatchShop.Domain.Identities.Extensibility
{
    public interface ITokenRepository
    {
        void Add(Token token);

        void Remove(Token token);
    }
}