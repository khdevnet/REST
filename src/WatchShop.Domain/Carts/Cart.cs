using System.Collections.Generic;

namespace WatchShop.Domain.Carts
{
    public class Cart
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public virtual IEnumerable<CartItem> Items { get; set; }
    }
}