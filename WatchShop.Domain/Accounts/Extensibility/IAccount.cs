using WatchShop.Domain.Accounts.Extensibility.Entities;

namespace WatchShop.Domain.Accounts.Extensibility
{
    public interface IAccount
    {
        int GetAccountId(string email);

        bool IsRegistered(string email);

        bool IsIdentified(string email, string password);

        void Register(Customer customer, string password);

        void Update(Customer customer);

        void UnRegister(string email);
    }
}