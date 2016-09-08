using AppUsage.Infrastructure.Data.Contexts;
using AppUsage.Infrastructure.Logging;
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

        private static int _instanceCounter = 0;
        private static int _instanceSequence = 0;

        private int instanceId { get; set; }

        public AppUsageDbContext() : base("AppUsageDbContext")
        {
            this.basicContextConfiguration();
        }

        public AppUsageDbContext(string connStr = "AppUsageDbContext") : base(connStr)
        {
            this.basicContextConfiguration();
        }

        public void Initialize(IDatabaseInitializer<DbContext> databaseInitializer = null)
        {
            this.log($"DbContext Instance {this.instanceId} - Initializing Database");
            Database.SetInitializer(databaseInitializer == null ? new DataSeedingInitializer() : databaseInitializer as IDatabaseInitializer<AppUsageDbContext>);

            Migrator.RunMigrations();

            this.Database.Initialize(force: true);
            this.log($"DbContext Instance {this.instanceId} - Initialized Database");
        }

        private void basicContextConfiguration()
        {
            _instanceCounter++;
            this.instanceId = _instanceSequence++;

            UnityEventLogger.Log.CreateUnityMessage($"Creating DbContext {this.instanceId} - Instance count: {_instanceCounter}");

            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = true;
            this.logSql();
        }

        [Conditional("DEBUG")]
        private void logSql() => this.Database.Log = s => Debug.WriteLine($"DbContext Instance {this.instanceId} - Instance count: {_instanceCounter} \n {s}");

        private void log(string log)
        {
            UnityEventLogger.Log.LogUnityMessage(log);
        }

        protected override void Dispose(bool disposing)
        {
            this.log($"Entered Dispose DbContext {this.instanceId}");

            base.Dispose(disposing);

            _instanceCounter--;
            UnityEventLogger.Log.DisposeUnityMessage($"Disposed DbContext {this.instanceId} - Instance count: {_instanceCounter}");
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
