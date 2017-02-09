using System.Web.Http;
using WatchShop.Api.Infrastructure.Authorization;
using WatchShop.Domain.Accounts.Extensibility;

namespace WatchShop.Api.Accounts
{
    public class CustomersController : ApiController
    {
        private readonly ICheckoutProcess checkoutProcess;

        public CustomersController(ICheckoutProcess checkoutProcess)
        {
            this.checkoutProcess = checkoutProcess;
        }

        [HttpPost]
        [SimpleAuthorize]
        public IHttpActionResult Checkout()
        {
            checkoutProcess.Checkout(User.Identity.Name);
            return Ok();
        }
    }
}