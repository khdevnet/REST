using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WatchShop.Api.Infrastructure.Authorization
{
    public class SimpleAuthorizeAttribute : AuthorizeAttribute
    {
        private const string CustomerEmailHeaderKey = "HTTP_CUSTOMER_EMAIL";
        private const string AuthorithationType = "simple";
        private readonly IEnumerable<string> allowedUsers = new[] { "anton@gmail.com" };

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            string userIdentity = GetUserIdentity(actionContext.Request.Headers);

            if (IsAuthorizedUser(userIdentity))
            {
                HandleAuthorizationRequest(userIdentity);
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

        private static void HandleAuthorizationRequest(string userName)
        {
            var identity = new UserIdentity(AuthorithationType, true, userName);
            var userPrincipal = new UserPrincipal(identity);

            Thread.CurrentPrincipal = userPrincipal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = userPrincipal;
            }
        }

        private static string GetUserIdentity(HttpRequestHeaders httpRequestHeaders)
        {
            string userIdentity = String.Empty;
            if (httpRequestHeaders.Contains(CustomerEmailHeaderKey))
            {
                userIdentity = httpRequestHeaders.GetValues(CustomerEmailHeaderKey).First();
            }
            return userIdentity;
        }

        private bool IsAuthorizedUser(string userIdentity)
        {
            return !String.IsNullOrWhiteSpace(userIdentity) && allowedUsers.Contains(userIdentity);
        }
    }
}