using AppUsage.Infrastructure.Data.Contexts;
using AppUsage.Model.Entities;
using AppUsage.Model.Initialization;
using System.Data.Entity;
using System.Diagnostics;

namespace AppUsage.Model.Contexts
{
    public class AppUsageDbContext : DbContext, IDbContext
    {
        public IDbSet<Device> Devices { get; set; }

        public IDbSet<Partner> Partners { get; set; }

        public IDbSet<Program> Programs { get; set; }

        //public AppUsageDbContext() : base("AppUsageDbContext")
        //{
        //    this.basicContextConfiguration();
        //}

        public AppUsageDbContext(string connStr = "AppUsageDbContext") : base(connStr)
        {
            this.basicContextConfiguration();
        }

        public void Initialize(IDatabaseInitializer<DbContext> databaseInitializer = null)
        {
            Database.SetInitializer(databaseInitializer == null ? new DataSeedingInitializer() : databaseInitializer as IDatabaseInitializer<AppUsageDbContext>);
            Migrator.RunMigrations();

            this.Database.Initialize(force: true);
        }

        private void basicContextConfiguration()
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
            this.logSql();
        }

        [Conditional("DEBUG")]
        private void logSql() => this.Database.Log = s => Debug.WriteLine(s);

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
