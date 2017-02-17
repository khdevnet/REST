using System.Linq;
using System.Web.Http;
using WatchShop.Api.Carts.Models;
using WatchShop.Api.Infrastructure.Authorization;
using WatchShop.Domain.Carts.Extensibility.Entities;
using WatchShop.Domain.Common.Extensibility;

namespace WatchShop.Api.Carts
{
    [TokenAuthorize]
    public class CartController : ApiController
    {
        private readonly IShopDataContext dataContext;

        public CartController(IShopDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IHttpActionResult Get()
        {
            Cart cart = dataContext.Carts.GetCart(User.Identity.Name);

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
            Cart cart = dataContext.Carts.GetCart(User.Identity.Name);
            cart.AddItem(cartItemViewModel.ProductId, cartItemViewModel.Quantity);

            dataContext.Carts.AddOrUpdateCart(cart);
            dataContext.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult Remove([FromBody]ProductCartItemRequestModel product)
        {
            Cart cart = dataContext.Carts.GetCart(User.Identity.Name);

            cart.RemoveItem(product.ProductId);
            dataContext.SaveChanges();

            return Ok();
        }
    }
}