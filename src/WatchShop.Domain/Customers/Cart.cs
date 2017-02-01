using System.Collections.Generic;
using System.Linq;

namespace WatchShop.Domain.Customers
{
    public class Cart
    {
        public Cart()
        {
            Items = new List<CartItem>();
        }

        public int Id { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual ICollection<CartItem> Items { get; set; }

        public void AddItem(int productId, int quantity)
        {
            CartItem cartItem = Items.FirstOrDefault(x => x.ProductId == productId);

            if (cartItem == null)
            {
                Items.Add(new CartItem
                {
                    ProductId = productId,
                    Quantity = quantity
                });
            }
            else
            {
                cartItem.Quantity = quantity;
            }
        }

        public decimal GetTotal()
        {
            return Items.Sum(item => item.Product.Price * item.Quantity);
        }

        public void RemoveItem(int productId)
        {
            CartItem item = Items.FirstOrDefault(x => x.ProductId == productId);

            if (item != null)
            {
                Items.Remove(item);
            }
        }
    }
}