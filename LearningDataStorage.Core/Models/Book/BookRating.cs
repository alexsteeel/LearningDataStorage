namespace LearningDataStorage.Core.Models
{
    /// <summary>
    /// Rating of book on site, for example, on amazon.
    /// </summary>
    public class BookRating
    {
        public BookRating(int siteId, decimal maxValue, decimal value)
        {
            SiteId = siteId;
            MaxValue = maxValue;
            Value = value;
        }

        public int Id { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int SiteId { get; set; }
        public Site Site { get; set; }

        public decimal MaxValue { get; set; }

        public decimal Value { get; set; }

    }
}
