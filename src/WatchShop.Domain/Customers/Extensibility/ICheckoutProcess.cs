namespace WatchShop.Domain.Customers.Extensibility
{
    public interface ICheckoutProcess
    {
        void Checkout(string customerEmail);
    }
}