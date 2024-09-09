using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLab.Academy.DbMigrator
{
    public class MigrationDbContextFactory : IDesignTimeDbContextFactory<MigrationDbContext>
    {
        public MigrationDbContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var configuration = builder.Build();
            var connectionString = configuration.GetConnectionString("ConnectionString");

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<MigrationDbContext>();
            dbContextOptionsBuilder.UseNpgsql(connectionString);
            return new MigrationDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
