using LearningDataStorage.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LearningDataStorage
{
    public class DBContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();

            var connectionString = new ConfigurationManager().GetConnectionString();
            optionsBuilder.UseSqlServer(connectionString,
                    x => x.MigrationsAssembly("LearningDataStorage.DAL"));

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}
