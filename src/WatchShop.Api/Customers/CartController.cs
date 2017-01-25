using System.Web.Http;
using WatchShop.Api.Infrastructure.Authorization;
using WatchShop.Domain.Customers;

namespace WatchShop.Api.Customers
{
    [SimpleAuthorize]
    public class CartController : ApiController
    {
        private readonly ICartRepository cartRepository;
        private readonly ICustomerRepository customerRepository;

        public CartController(ICartRepository cartRepository, ICustomerRepository customerRepository)
        {
            this.cartRepository = cartRepository;
            this.customerRepository = customerRepository;
        }

        [HttpPost]
        public void Add([FromBody]CartItemViewModel cartItemViewModel)
        {
            Cart cart = cartRepository.GetCart(User.Identity.Name);

            var cartItem = new CartItem(cartItemViewModel.ProductId);

            cart.Items.Add(cartItem);

            cartRepository.Update(cart);

            // cart id get by user 
            // cartRepository add cartItem (cartId,productId,qty,)
            // cart rep save
        }
    }
}