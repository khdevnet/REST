using System.Web.Http;
using WatchShop.Api.Infrastructure.Authorization;
using WatchShop.Domain.Accounts.Extensibility;

namespace WatchShop.Api.Checkout
{
    public class CheckoutController : ApiController
    {
        private readonly ICheckoutProcessor checkoutProcessor;

        public CheckoutController(ICheckoutProcessor checkoutProcessor)
        {
            this.checkoutProcessor = checkoutProcessor;
        }

        [HttpPost]
        [TokenAuthorize]
        public IHttpActionResult Process()
        {
            checkoutProcessor.Process(User.Identity.Name);
            return Ok();
        }
    }
}