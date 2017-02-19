using WatchShop.Domain.Accounts.Extensibility.Entities;

namespace WatchShop.Domain.Identities.Extensibility.Entities
{
    public class Identity
    {
        public int Id { get; set; }

        public string Password { get; set; }

        public virtual Customer Customer { get; set; }
    }
}