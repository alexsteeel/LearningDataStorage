using LearningDataStorage.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningDataStorage.DAL
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(500);

            builder
                .HasOne(b => b.BookCover)
                .WithOne(i => i.Book)
                .HasForeignKey<BookCover>(b => b.BookId);

            builder
                .Property(m => m.Annotation)
                .IsRequired()
                .HasMaxLength(1000);

            builder
                .HasMany(p => p.Ratings)
                .WithOne(i => i.Book)
                .HasForeignKey(b => b.BookId);

            builder
                .HasMany(p => p.Quotes)
                .WithOne(i => i.Book)
                .HasForeignKey(b => b.BookId);

            builder
                .HasMany(p => p.Notes)
                .WithOne(i => i.Book)
                .HasForeignKey(b => b.BookId);

            builder
                .HasMany(p => p.Categories)
                .WithOne(i => i.Book)
                .HasForeignKey(b => b.BookId);

            builder
                .ToTable("Books", "data");
        }
    }
}
