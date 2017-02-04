using System.Data.Entity;
using System.Linq;
using WatchShop.Domain.Carts.Extensibility;
using WatchShop.Domain.Carts.Extensibility.Entities;
using WatchShop.Domain.Common;
using WatchShop.Domain.Database;

namespace WatchShop.Domain.Carts
{
    internal class CartRepository : RepositoryBase, ICartRepository
    {
        public CartRepository(IShopDbContext context) : base(context)
        {
        }

        public Cart GetCart(string customerEmail)
        {
            Cart cartEntity = context.Carts
                .Include(x => x.Items.Select(item => item.Product))
                .FirstOrDefault(c => c.Customer.Email == customerEmail);

            if (cartEntity == null)
            {
                cartEntity = new Cart
                {
                    Id = context.Customers.Single(c => c.Email == customerEmail).Id,
                    Customer = context.Customers.Single(c => c.Email == customerEmail)
                };
            }
            return cartEntity;
        }

        public void AddOrUpdateCart(Cart cart)
        {
            if (!context.Carts.Any(c => c.Id == cart.Id))
            {
                context.Carts.Add(cart);
            }
        }

        public void Remove(Cart cart)
        {
            context.Carts.Remove(cart);
        }
    }
}