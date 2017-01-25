using System.Web.Http;
using WatchShop.Api.Infrastructure.Authorization;

namespace WatchShop.Api.Customers
{
    [SimpleAuthorize]
    public class CartController : ApiController
    {
        [HttpPost]
        public void Add(CartItemViewModel cartItemViewModel)
        {
            // cart id get by user 
            // cartRepository add cartItem (cartId,productId,qty,)
            // cart rep save
        }
    }
}