namespace WatchShop.Domain.Accounts.Extensibility
{
    public interface ICheckoutProcessor
    {
        void Process(string customerEmail);
    }
}