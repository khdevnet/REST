using WatchShop.Domain.Carts.Extensibility.Entities;

namespace WatchShop.Domain.Carts.Extensibility
{
    public interface ICartRepository
    {
        Cart GetCart(string customerEmail);

        void AddOrUpdateCart(Cart cart);

        void Remove(Cart cart);
    }
}