using System.Security.Principal;

namespace WatchShop.Api.Infrastructure.Authorization
{
    public class UserIdentity : IIdentity
    {
        public UserIdentity(string authenticationType, bool isAuthenticated, string name)
        {
            AuthenticationType = authenticationType;
            IsAuthenticated = isAuthenticated;
            Name = name;
        }

        public string AuthenticationType { get; }

        public bool IsAuthenticated { get; }

        public string Name { get; }
    }
}