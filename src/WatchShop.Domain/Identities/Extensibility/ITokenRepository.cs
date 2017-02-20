using WatchShop.Domain.Identities.Extensibility.Entities;

namespace WatchShop.Domain.Identities.Extensibility
{
    public interface ITokenRepository
    {
        void Add(Token token);

        bool IsExist(string email);

        string GetTokenByEmail(string email);

        Token GetToken(string token);

        bool IsTokenExist(string token);

        void Remove(Token token);
    }
}