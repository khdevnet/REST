using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace WatchShop.Api.Infrastructure.Authorization
{
    public class SimpleAuthorizeAttribute : AuthorizeAttribute
    {
        private const string CustomerEmailHeaderKey = "HTTP_CUSTOMER_EMAIL";

        private readonly IEnumerable<string> allowedUsers = new[] { "anton@gmail.com" };

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Contains(CustomerEmailHeaderKey))
            {
                string userName = actionContext.Request.Headers.GetValues(CustomerEmailHeaderKey).First();

                if (!String.IsNullOrWhiteSpace(userName) && allowedUsers.Contains(userName))
                {
                    HandleAuthorization(userName);
                }
                else
                {
                    actionContext.Response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                }
            }
        }

        private static void HandleAuthorization(string userName)
        {
            var identity = new UserIdentity("simple", true, userName);
            var userPrincipal = new UserPrincipal(identity);

            Thread.CurrentPrincipal = userPrincipal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = userPrincipal;
            }
        }
    }
}