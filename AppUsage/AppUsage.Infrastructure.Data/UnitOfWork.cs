using AppUsage.Infrastructure.Data.Base;
using AppUsage.Infrastructure.Data.Contexts;
using AppUsage.Infrastructure.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace AppUsage.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        //[Dependency]
        internal IDbContext _context { get; set; }

        public UnitOfWork(IDbContext context)
        {
            this._context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        private bool _disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                    _context.Dispose();

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

    public class UnitOfWork<TEntity> : UnitOfWork, IUnitOfWork<TEntity> where TEntity : BaseEntity
    {
        public UnitOfWork(IDbContext context, IRepository<TEntity> repository) : base(context)
        {
            this.Repository = repository;
        }

        //[Dependency]
        public IRepository<TEntity> Repository { get; set; }
    }
}
