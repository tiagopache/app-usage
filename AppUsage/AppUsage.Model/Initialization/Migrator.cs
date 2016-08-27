using AppUsage.Model.Migrations;
using System.Data.Entity.Migrations;

namespace AppUsage.Model.Initialization
{
    public class Migrator
    {
        public static void RunMigrations()
        {
            var migrationConfigurations = new AppUsageConfiguration();
            var dbMigrator = new DbMigrator(migrationConfigurations);

            dbMigrator.Update();
        }
    }
}
