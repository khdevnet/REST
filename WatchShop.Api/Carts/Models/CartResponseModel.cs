using System.Collections.Generic;

namespace WatchShop.Api.Carts.Models
{
    public class CartResponseModel
    {
        public IEnumerable<CartItemResponseModel> Items { get; set; }

        public decimal Total { get; set; }
    }
}