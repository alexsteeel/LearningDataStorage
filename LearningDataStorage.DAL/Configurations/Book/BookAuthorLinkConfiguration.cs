using LearningDataStorage.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningDataStorage.DAL
{
    public class BookAuthorLinkConfiguration : IEntityTypeConfiguration<BookAuthorLink>
    {
        public void Configure(EntityTypeBuilder<BookAuthorLink> builder)
        {
            builder
                .HasKey(t => new { t.BookId, t.AuthorId });

            builder
               .HasOne(bal => bal.Book)
               .WithMany(b => b.BookAuthorLinks)
               .HasForeignKey(bal => bal.BookId);

            builder
               .HasOne(bal => bal.Author)
               .WithMany(b => b.BookAuthorLinks)
               .HasForeignKey(bal => bal.AuthorId);

            builder
                .ToTable("BookAuthorLinks", "data");
        }
    }
}
