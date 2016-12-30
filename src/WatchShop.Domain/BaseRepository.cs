using System;

namespace WatchShop.Domain
{
    public class BaseRepository : IDisposable
    {
        protected readonly ShopDbContext Db = new ShopDbContext();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db?.Dispose();
            }
        }
    }
}