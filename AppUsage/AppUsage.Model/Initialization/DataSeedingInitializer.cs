using AppUsage.Model.Contexts;
using AppUsage.Model.Migrations;
using System.Data.Entity;

namespace AppUsage.Model.Initialization
{
    public class DataSeedingInitializer : MigrateDatabaseToLatestVersion<AppUsageDbContext, AppUsageConfiguration> { }
}
