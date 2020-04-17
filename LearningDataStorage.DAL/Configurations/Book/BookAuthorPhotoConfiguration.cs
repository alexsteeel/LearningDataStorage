using LearningDataStorage.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningDataStorage.DAL
{
    public class BookAuthorPhotoConfiguration : IEntityTypeConfiguration<BookAuthorPhoto>
    {
        public void Configure(EntityTypeBuilder<BookAuthorPhoto> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .ToTable("BookAuthorPhoto", "data");
        }
    }
}
