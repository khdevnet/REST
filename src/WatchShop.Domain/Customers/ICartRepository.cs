namespace WatchShop.Domain.Customers
{
    public interface ICartRepository
    {
        void Add(int customerId, CartItem cartItem);

        Cart GetCart(int customerId);

        void Remove(CartItem cartItem);
    }
}