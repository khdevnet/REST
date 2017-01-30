using System.Web.Http;
using WatchShop.Api.Infrastructure.Authorization;
using WatchShop.Domain.Customers;

namespace WatchShop.Api.Customers
{
    [SimpleAuthorize]
    public class CartController : ApiController
    {
        private readonly ICartRepository cartRepository;

        public CartController(ICartRepository cartRepository)
        {
            this.cartRepository = cartRepository;
        }

        [HttpPost]
        public void Add([FromBody]CartItemViewModel cartItemViewModel)
        {
            Cart cart = cartRepository.GetCart(User.Identity.Name);

            cart.Items.Add(new CartItem(cartItemViewModel.ProductId, cartItemViewModel.Quantity));

            cartRepository.Update(cart);
        }
    }
}