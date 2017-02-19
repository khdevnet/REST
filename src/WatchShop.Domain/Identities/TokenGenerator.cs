using System;
using WatchShop.Domain.Identities.Extensibility;

namespace WatchShop.Domain.Identities
{
    internal class TokenGenerator : ITokenGenerator
    {
        public string Generate()
        {
            return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
        }
    }
}