namespace WatchShop.Domain.Customers
{
    public interface ICartRepository
    {
        void Update(Cart cart);

        Cart GetCart(string customerEmail);
    }
}