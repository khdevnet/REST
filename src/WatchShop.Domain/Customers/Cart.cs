using System.Collections.Generic;
using System.Linq;

namespace WatchShop.Domain.Customers
{
    public class Cart
    {
        private readonly List<CartItem> items;

        public Cart(int customerId, List<CartItem> items = null)
        {
            CustomerId = customerId;
            this.items = items ?? new List<CartItem>();
        }

        protected Cart()
        {
            items = new List<CartItem>();
        }

        public int CustomerId { get; }

        public IEnumerable<CartItem> GetItems()
        {
            return items.ToList();
        }

        public void AddItem(int productId, int quantity)
        {
            CartItem cartItem = items.FirstOrDefault(x => x.ProductId == productId);

            if (cartItem == null)
            {
                items.Add(new CartItem(productId, quantity));
            }
            else
            {
                cartItem.UpdateQuantity(quantity);
            }
        }
    }
}