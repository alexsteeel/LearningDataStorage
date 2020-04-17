using LearningDataStorage.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LearningDataStorage.DAL
{
    public class BookNoteConfiguration : IEntityTypeConfiguration<BookNote>
    {
        public void Configure(EntityTypeBuilder<BookNote> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .ToTable("Notes", "data");
        }
    }
}
