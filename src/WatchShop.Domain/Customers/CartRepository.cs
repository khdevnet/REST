using System.Data.Entity;
using System.Linq;

namespace WatchShop.Domain.Customers
{
    internal class CartRepository : RepositoryBase, ICartRepository
    {
        public Cart GetCart(string customerEmail)
        {
            Cart cartEntity = Db.Carts
                .Include(x => x.Items.Select(item => item.Product))
                .FirstOrDefault(c => c.Customer.Email == customerEmail);

            if (cartEntity == null)
            {
                cartEntity = new Cart
                {
                    Id = Db.Customers.Single(c => c.Email == customerEmail).Id,
                    Customer = Db.Customers.Single(c => c.Email == customerEmail)
                };
            }
            return cartEntity;
        }

        public void AddOrUpdateCart(Cart cart)
        {
            if (!Db.Carts.Any(c => c.Id == cart.Id))
            {
                Db.Carts.Add(cart);
            }
        }
    }
}