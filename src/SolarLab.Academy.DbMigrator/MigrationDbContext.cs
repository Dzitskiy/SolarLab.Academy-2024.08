using Microsoft.EntityFrameworkCore;
using SolarLab.Academy.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLab.Academy.DbMigrator
{
    public class MigrationDbContext : AcademyDbContext
    {
        public MigrationDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
