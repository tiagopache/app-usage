using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Data.Entity;

namespace AppUsage.Infrastructure.Data.Contexts
{
    public interface IDbContext : IDisposable
    {
        void Initialize(IDatabaseInitializer<DbContext> databaseInitializer = null);
        Database Database { get; }
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
