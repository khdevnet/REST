using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using Ninject;
using WatchShop.Domain.Common.Extensibility;
using WatchShop.Domain.Identities.Extensibility;

namespace WatchShop.Api.Infrastructure.Authorization
{
    public class TokenAuthorizeAttribute : AuthorizeAttribute
    {
        private const string HttpTokenKey = "HTTP_TOKEN";
        private const string AuthorithationType = "TokenAuthorization";
        [Inject]
        public ITokenIdentifier TokenIdentifier { get; set; }
        [Inject]
        public IShopDataContext DataContext { get; set; }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            string accountToken = GetToken(actionContext.Request.Headers);

            if (IsAuthorizedUser(accountToken))
            {
                HandleAuthorizationRequest(accountToken);
            }
            else
            {
                HandleUnAuthorizedRequest(actionContext);
            }
        }

        private static void HandleUnAuthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
        }

        private void HandleAuthorizationRequest(string token)
        {
            var customer = DataContext.Customers.GetCustomerByToken(token);
            var identity = new UserIdentity(AuthorithationType, true, customer.Email);
            var userPrincipal = new UserPrincipal(identity);

            Thread.CurrentPrincipal = userPrincipal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = userPrincipal;
            }
        }

        private static string GetToken(HttpRequestHeaders httpRequestHeaders)
        {
            string userToken = String.Empty;
            if (httpRequestHeaders.Contains(HttpTokenKey))
            {
                userToken = httpRequestHeaders.GetValues(HttpTokenKey).First();
            }
            return userToken;
        }

        private bool IsAuthorizedUser(string accountToken)
        {
            return !String.IsNullOrWhiteSpace(accountToken) && TokenIdentifier.ValidateToken(accountToken);
        }
    }
}