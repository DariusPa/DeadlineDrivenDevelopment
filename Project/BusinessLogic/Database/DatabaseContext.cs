using Database.Models;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class DatabaseContext : DbContext
    {
        // this string along with the parameterless constructor is here solely for the purpose of creating a new migration:
        // since dotnet ef command line tool does not accept a connection string as a command line parameter, we have to hardcode it here.
        private const string _azureDbDonnectionString = "";

        public DbSet<LearningDay> LearningDays { get; set; }

        public DatabaseContext() : base(GetOptions())
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        private static DbContextOptions GetOptions()
        {
            return SqlServerDbContextOptionsExtensions
                .UseSqlServer(new DbContextOptionsBuilder(), _azureDbDonnectionString)
                .Options;
        }
    }
}