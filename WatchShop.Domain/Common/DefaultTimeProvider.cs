using System;

namespace WatchShop.Domain.Common
{
    public class DefaultTimeProvider : TimeProvider
    {
        public override DateTime Now
        {
            get { return DateTime.Now; }
        }
    }
}