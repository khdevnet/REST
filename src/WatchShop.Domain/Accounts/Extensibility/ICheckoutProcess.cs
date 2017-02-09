namespace WatchShop.Domain.Accounts.Extensibility
{
    public interface ICheckoutProcess
    {
        void Checkout(string customerEmail);
    }
}