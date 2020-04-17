using System.Collections.Generic;

namespace LearningDataStorage.Core.Models
{
    public class Book
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<BookAuthorLink> BookAuthorLinks { get; set; }

        public BookCover BookCover { get; set; }

        public string Annotation { get; set; }

        public int PagesCount { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public int PublishingHouseId { get; set; }
        public PublishingHouse PublishingHouse { get; set; }

        public int Year { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }        

        public ICollection<BookRating> Ratings { get; set; }

        public ICollection<BookQuote> Quotes { get; set; }

        public ICollection<BookNote> Notes { get; set; }

        public ICollection<BookCategory> Categories { get; set; }

    }
}
