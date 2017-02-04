using WatchShop.Domain.Common;

namespace WatchShop.Domain.Customers
{
    public interface ICartRepository : IRepositoryBase
    {
        Cart GetCart(string customerEmail);

        void AddOrUpdateCart(Cart cart);
    }
}