using System.Collections.Generic;

namespace LearningDataStorage
{
    /// <summary>
    /// Текст, видео, статья или другой объект, который можно процитировать.
    /// </summary>
    public interface IHasQuotes<IQuote>
    {
        public int Id { get; set; }

        /// <summary>
        /// Цитаты.
        /// </summary>
        ICollection<BookQuote> Quotes { get; set; }
    }
}
