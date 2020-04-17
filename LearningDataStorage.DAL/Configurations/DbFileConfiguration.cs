using LearningDataStorage.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningDataStorage.DAL
{
    public class DbFileConfiguration : IEntityTypeConfiguration<DbFile>
    {
        public void Configure(EntityTypeBuilder<DbFile> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.FileType)
                .IsRequired()
                .HasMaxLength(10);

            builder
                .ToTable("DbFiles", "data");
        }
    }
}
