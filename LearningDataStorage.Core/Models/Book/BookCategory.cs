namespace LearningDataStorage.Core.Models
{
    public class BookCategory
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

    }
}
