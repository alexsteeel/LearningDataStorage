using LearningDataStorage.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;

namespace LearningDataStorage.DAL
{
    public class ApplicationContext : DbContext
    {
        #region DbSets

        public DbSet<BookAuthorPhoto> AuthorPhoto { get; set; }

        public DbSet<BookAuthor> Authors { get; set; }
        
        public DbSet<Book> Books { get; set; }

        public DbSet<PublishingHouse> PublishingHouses { get; set; }

        public DbSet<BookNote> Notes { get; set; }

        public DbSet<BookQuote> Quotes { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<BookCover> BookCovers { get; set; }

        public DbSet<DbFile> DbFiles { get; set; }

        #endregion DbSets

        public ApplicationContext()
        {
            
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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Book
            builder.ApplyConfiguration(new BookAuthorConfiguration());
            builder.ApplyConfiguration(new BookAuthorLinkConfiguration());
            builder.ApplyConfiguration(new BookAuthorPhotoConfiguration());
            builder.ApplyConfiguration(new BookCategoryConfiguration());
            builder.ApplyConfiguration(new BookConfiguration());
            builder.ApplyConfiguration(new BookCoverConfiguration());
            builder.ApplyConfiguration(new BookQuoteConfiguration());
            builder.ApplyConfiguration(new BookRatingConfiguration());
            builder.ApplyConfiguration(new PublishingHouseConfiguration());

            // Common
            builder.ApplyConfiguration(new CityConfiguration());
            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new LanguageConfiguration());

            // Site
            builder.ApplyConfiguration(new LinkConfiguration());
            builder.ApplyConfiguration(new SiteConfiguration());

            // Other
            builder.ApplyConfiguration(new DbFileConfiguration());
            builder.ApplyConfiguration(new BookNoteConfiguration());
            

            // from https://www.iban.com/country-codes
            builder.Entity<Country>()
                .HasData(
                    new Country(1, "Russian Federation", "RUS"),                    
                    new Country(2, "United States of America", "USA")
                );

            builder.Entity<City>()
                .HasData(
                    new City(1, "Moscow", 1)
                );

            builder.Entity<Language>()
                .HasData(
                    new Language(1, "English", "eng"),
                    new Language(2, "Russian", "rus")
                );
        }
    }
}
