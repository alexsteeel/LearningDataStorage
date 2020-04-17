namespace LearningDataStorage.Core.Models
{
    public class BookAuthorPhoto : IPhoto
    {
        public int Id { get; set; }

        public int FileId { get; set; }

        public int AuthorId { get; set; }

        public BookAuthor Author { get; set; }

    }
}
