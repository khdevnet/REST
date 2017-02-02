using System.Linq;
using System.Web.Http;
using WatchShop.Api.Customers.CartModels;
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

        public CartResponseModel Get()
        {
            Domain.Customers.Cart cart = cartRepository.GetCart(User.Identity.Name);

            return new CartResponseModel
            {
                Items = cart.Items
                .Select(item => new CartItemResponseModel
                {
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    Name = item.Product.Name,
                    Price = item.Product.Price
                }),
                Total = cart.GetTotal()
            };
        }

        [HttpPost]
        public void Add([FromBody]AddCartItemRequestModel cartItemViewModel)
        {
            Cart cart = cartRepository.GetCart(User.Identity.Name);

            cart.AddItem(cartItemViewModel.ProductId, cartItemViewModel.Quantity);

            cartRepository.Update(cart);
        }

        [HttpPost]
        public void Remove([FromBody]ProductCartItemRequestModel product)
        {
            Cart cart = cartRepository.GetCart(User.Identity.Name);

            cart.RemoveItem(product.ProductId);

            cartRepository.Update(cart);
        }
    }
}