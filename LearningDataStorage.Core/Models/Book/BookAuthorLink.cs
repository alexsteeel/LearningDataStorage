namespace LearningDataStorage.Core.Models
{
    public class BookAuthorLink
    {
        public int BookId { get; set; }
        public Book Book { get; set; }

        public int AuthorId { get; set; }
        public BookAuthor Author { get; set; }
    }
}
