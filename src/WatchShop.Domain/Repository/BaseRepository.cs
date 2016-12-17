using System;
using WatchShop.Domain.Database;

namespace WatchShop.Domain.Repository
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
                if (Db != null)
                {
                    Db.Dispose();
                }
            }
        }
    }
}