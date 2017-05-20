using System;

namespace WatchShop.Domain.Common
{
    public abstract class TimeProvider
    {
        private static TimeProvider current;

        static TimeProvider()
        {
            TimeProvider.current =
                new DefaultTimeProvider();
        }

        public static TimeProvider Current
        {
            get
            {
                return current;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                current = value;
            }
        }

        public abstract DateTime Now { get; }

        public static void ResetToDefault()
        {
            TimeProvider.current =
                new DefaultTimeProvider();
        }
    }
}