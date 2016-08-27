using AppUsage.Infrastructure.Data.Base;
using AppUsage.Infrastructure.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace AppUsage.Infrastructure.Data
{
    public interface IUnitOfWork : IDisposable
    {
        void Save();

        Task<int> SaveAsync();
    }

    public interface IUnitOfWork<TEntity> : IUnitOfWork where TEntity : BaseEntity
    {
        IRepository<TEntity> Repository { get; set; }
    }

}
