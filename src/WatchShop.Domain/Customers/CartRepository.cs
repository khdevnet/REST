using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace WatchShop.Domain.Customers
{
    internal class CartRepository : BaseRepository, ICartRepository
    {
        public void Update(Cart cart)
        {
            if (cart == null)
            {
                cart = new Cart { Customer = Db.Customers.FirstOrDefault(x => x.Id == cart.Id) };
                Db.Carts.Add(cart);
            }

            DeleteRemovedItemsFromCart(cart.Items);

            UpdateExistCartItems(cart.Items);

            Db.SaveChanges();
        }

        public Cart GetCart(string customerEmail)
        {
            Cart cartEntity = Db.Carts
                .Include(x => x.Items.Select(item => item.Product))
                .FirstOrDefault(c => c.Customer.Email == customerEmail);

            if (cartEntity == null)
            {
                cartEntity = new Cart
                {
                    Id = Db.Customers.Single(c => c.Email == customerEmail).Id
                };
            }
            return cartEntity;
        }

        private void UpdateExistCartItems(ICollection<CartItem> cartItems)
        {
            foreach (CartItem item in cartItems.ToList())
            {
                CartItem cartItemEntity = Db.CartItems.FirstOrDefault(ci => ci.ProductId == item.ProductId);

                if (cartItemEntity == null)
                {
                    cartItemEntity = new CartItem
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity
                    };
                    cartItems.Add(cartItemEntity);
                }
                else
                {
                    cartItemEntity.Quantity = item.Quantity;
                }
            }
        }

        private void DeleteRemovedItemsFromCart(IEnumerable<CartItem> cartItems)
        {
            IEnumerable<int> itemsProductIds = cartItems.Select(x => x.ProductId);
            IQueryable<int> removeItemsIds = Db.CartItems.Select(x => x.ProductId).Where(x => !itemsProductIds.Contains(x));
            Db.CartItems.Where(x => removeItemsIds.Contains(x.ProductId)).ToList().ForEach(item => Db.CartItems.Remove(item));
        }
    }
}