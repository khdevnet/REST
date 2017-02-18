using WatchShop.Domain.Accounts.Extensibility.Entities;

namespace WatchShop.Domain.Identities
{
    public class Identity
    {
        public int Id { get; set; }

        public string Password { get; set; }

        public virtual Customer Customer { get; set; }
    }
}