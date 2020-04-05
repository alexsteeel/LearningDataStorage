﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;

namespace LearningDataStorage.DAL
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

        /// <summary>
        /// Обложки книг.
        /// </summary>
        public DbSet<BookCover> BookCovers { get; set; }

        /// <summary>
        /// Фотографии авторов.
        /// </summary>
        public DbSet<AuthorPhoto> AuthorPhoto { get; set; }

        /// <summary>
        /// Файлы.
        /// </summary>
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // https://www.iban.com/country-codes
            modelBuilder.Entity<Country>()
                .HasData(
                    new Country(1, "Russian Federation", "RUS"),                    
                    new Country(2, "United States of America (the)", "USA")
                );

            modelBuilder.Entity<City>()
                .HasData(
                    new City(1, "Moscow", 1)
                );

            modelBuilder.Entity<Language>()
                .HasData(
                    new Language(1, "English", "eng"),
                    new Language(2, "Russian", "rus")
                );
        }
    }
}
