using System;
using System.Security.Principal;

namespace WatchShop.Api.Infrastructure.Authorization
{
    public class UserPrincipal : IPrincipal
    {
        public UserPrincipal(IIdentity identity)
        {
            Identity = identity;
        }

        public IIdentity Identity { get; }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }
}