namespace LearningDataStorage.Core.Models
{
    public class BookNote
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }
    }
}