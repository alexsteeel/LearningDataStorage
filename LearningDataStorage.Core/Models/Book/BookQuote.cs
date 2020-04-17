using System.Collections.Generic;

namespace LearningDataStorage.Core.Models
{
    public class BookQuote : IQuote
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public int PageNumber { get; set; }

        public int BookId { get; set; }
        public Book Book{ get; set; }

        public ICollection<BookNote> Notes { get; set; }

    }
}
