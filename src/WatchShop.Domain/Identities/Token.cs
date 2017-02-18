using System;
using WatchShop.Domain.Accounts.Extensibility.Entities;

namespace WatchShop.Domain.Identities
{
    public class Token
    {
        public int Id { get; set; }

        public string Value { get; set; }

        public DateTime GenerationTime { get; set; }

        public DateTime ExpiredTime { get; set; }

        public virtual Customer Customer { get; set; }
    }
}