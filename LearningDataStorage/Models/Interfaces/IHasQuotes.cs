using System.Collections.Generic;

namespace LearningDataStorage
{
    /// <summary>
    /// Текст, видео, статья или другой объект, который можно процитировать.
    /// </summary>
    public interface IHasQuotes<IQuote>
    {
        /// <summary>
        /// Цитаты.
        /// </summary>
        ICollection<IQuote> Quotes { get; set; }
    }
}
