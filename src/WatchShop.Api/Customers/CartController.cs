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
        private readonly ICustomerRepository customerRepository;

        public CartController(ICartRepository cartRepository, ICustomerRepository customerRepository)
        {
            this.cartRepository = cartRepository;
            this.customerRepository = customerRepository;
        }

        public IHttpActionResult Get()
        {
            Cart cart = cartRepository.GetCart(User.Identity.Name);

            return Ok(new CartResponseModel
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
            });
        }

        [HttpPost]
        public IHttpActionResult Add([FromBody]AddCartItemRequestModel cartItemViewModel)
        {
            Cart cart = cartRepository.GetCart(User.Identity.Name);
            cart.AddItem(cartItemViewModel.ProductId, cartItemViewModel.Quantity);

            cartRepository.AddOrUpdateCart(cart);
            cartRepository.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Remove([FromBody]ProductCartItemRequestModel product)
        {
            Cart cart = cartRepository.GetCart(User.Identity.Name);

            cart.RemoveItem(product.ProductId);

            cartRepository.SaveChanges();

            return Ok();
        }
    }
}