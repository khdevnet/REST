using System.Collections.Generic;

namespace WatchShop.Api.Customers
{
    public class CartResponseModel
    {
        public IEnumerable<CartItemResponseModel> Items { get; set; }

        public decimal Total { get; set; }
    }
}