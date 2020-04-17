using LearningDataStorage.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningDataStorage.DAL
{
    public class BookCoverConfiguration : IEntityTypeConfiguration<BookCover>
    {
        public void Configure(EntityTypeBuilder<BookCover> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .ToTable("BookCovers", "file");
        }
    }
}
