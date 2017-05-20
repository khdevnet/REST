using System.Linq;
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

        public string GetTokenByEmail(string email)
        {
            return context.Tokens.Single(t => t.Customer.Email == email).Value;
        }

        public Token GetToken(string token)
        {
            return context.Tokens.Single(t => t.Value == token);
        }

        public bool IsTokenExist(string token)
        {
            return context.Tokens.Any(t => t.Value == token);
        }

        public bool IsExist(string email)
        {
            return context.Tokens.Any(t => t.Customer.Email == email);
        }

        public void Remove(Token token)
        {
            context.Tokens.Remove(token);
        }
    }
}