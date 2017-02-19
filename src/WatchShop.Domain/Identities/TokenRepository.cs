using WatchShop.Domain.Common;
using WatchShop.Domain.Database;
using WatchShop.Domain.Identities.Extensibility;
using WatchShop.Domain.Identities.Extensibility.Entities;

namespace WatchShop.Domain.Identities
{
    internal class TokenRepository : RepositoryBase, ITokenRepository
    {
        public TokenRepository(IShopDbContext context) : base(context)
        {
        }

        public void Add(Token token)
        {
            context.Tokens.Add(token);
        }

        public void Remove(Token token)
        {
            context.Tokens.Remove(token);
        }
    }
}