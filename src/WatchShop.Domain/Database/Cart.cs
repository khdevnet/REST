using System.Collections.Generic;

namespace WatchShop.Domain.Database
{
    internal class Cart
    {
        public Cart()
        {
            Items = new List<CartItem>();
        }

        public int Id { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<CartItem> Items { get; set; }
    }
}