namespace LearningDataStorage.Core.Models
{
    public class BookCover
    {
        public BookCover(int fileId, int bookId)
        {
            FileId = fileId;
            BookId = bookId;
        }

        public int Id { get; set; }

        public int FileId { get; set; }
        public DbFile File { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}
