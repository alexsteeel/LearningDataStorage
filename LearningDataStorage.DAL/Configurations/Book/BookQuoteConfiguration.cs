using LearningDataStorage.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningDataStorage.DAL
{
    public class BookQuoteConfiguration : IEntityTypeConfiguration<BookQuote>
    {
        public void Configure(EntityTypeBuilder<BookQuote> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .ToTable("BookQuotes", "data");
        }
    }
}
