using System;
using WatchShop.Domain.Accounts.Extensibility;
using WatchShop.Domain.Common;
using WatchShop.Domain.Common.Extensibility;
using WatchShop.Domain.Identities.Extensibility;
using WatchShop.Domain.Identities.Extensibility.Entities;

namespace WatchShop.Domain.Identities
{
    internal class TokenIdentifier : ITokenIdentifier
    {
        private readonly IAccount account;
        private readonly ITokenGenerator tokenGenerator;
        private readonly IShopDataContext dataContext;

        public TokenIdentifier(IAccount account, IShopDataContext dataContext, ITokenGenerator tokenGenerator)
        {
            this.account = account;
            this.tokenGenerator = tokenGenerator;
            this.dataContext = dataContext;
        }

        public string GenerateToken(string email, string password)
        {
            if (dataContext.Tokens.IsExist(email))
            {
                return dataContext.Tokens.GetTokenByEmail(email);
            }

            if (account.IsIdentified(email, password))
            {
                var token = new Token
                {
                    Value = tokenGenerator.Generate(),
                    GenerationTime = TimeProvider.Current.Now,
                    ExpiredTime = GetExpiredTime(),
                    Id = account.GetAccountId(email)
                };
                dataContext.Tokens.Add(token);
                dataContext.SaveChanges();

                return token.Value;
            }

            return String.Empty;
        }

        public bool ValidateToken(string token)
        {
            if (dataContext.Tokens.IsTokenExist(token))
            {
                var tokenEntity = dataContext.Tokens.GetToken(token);
                if (tokenEntity.ExpiredTime >= TimeProvider.Current.Now)
                {
                    return true;
                }
                RemoveToken(tokenEntity);
            }

            return false;
        }

        private void RemoveToken(Token tokenEntity)
        {
            dataContext.Tokens.Remove(tokenEntity);
            dataContext.SaveChanges();
        }

        private static DateTime GetExpiredTime()
        {
            return TimeProvider.Current.Now + TimeSpan.FromDays(1);
        }
    }
}