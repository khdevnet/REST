using System;
using WatchShop.Domain.Common;
using WatchShop.Domain.Database;

namespace WatchShop.Domain
{
    internal abstract class RepositoryBase : IDisposable, IRepositoryBase
    {
        protected readonly ShopDbContext Db = new ShopDbContext();

        public virtual void SaveChanges()
        {
            Db.SaveChanges();
        }

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