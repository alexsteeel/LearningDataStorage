using LearningDataStorage.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningDataStorage.DAL
{
    public class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
               .Property(m => m.Surname)
               .IsRequired()
               .HasMaxLength(100);

            builder
               .Property(m => m.Name)
               .IsRequired()
               .HasMaxLength(100);

            builder
               .Property(m => m.Patronymic)
               .IsRequired()
               .HasMaxLength(100);

            builder
                .ToTable("Authors", "data");
        }
    }
}
