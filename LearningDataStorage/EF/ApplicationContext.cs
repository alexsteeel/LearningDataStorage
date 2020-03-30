using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using System.IO;

namespace LearningDataStorage
{
    public class ApplicationContext : DbContext
    {
        #region DbSets

        /// <summary>
        /// Авторы.
        /// </summary>
        public DbSet<Author> Authors { get; set; }
        
        /// <summary>
        /// Книги.
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Издательства.
        /// </summary>
        public DbSet<PublishingHouse> PublishingHouses { get; set; }

        /// <summary>
        /// Заметки.
        /// </summary>
        public DbSet<Note> Notes { get; set; }

        /// <summary>
        /// Цитаты.
        /// </summary>
        public DbSet<BookQuote> Quotes { get; set; }

        /// <summary>
        /// Страны.
        /// </summary>
        public DbSet<Country> Countries { get; set; }

        /// <summary>
        /// Города.
        /// </summary>
        public DbSet<City> Cities { get; set; }

        /// <summary>
        /// Языки.
        /// </summary>
        public DbSet<Language> Languages { get; set; }

        #endregion DbSets

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = GetConnectionString();
            optionsBuilder.UseSqlServer(connectionString);
        }

        private string GetConnectionString()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            return connectionString;
        }
    }
}
