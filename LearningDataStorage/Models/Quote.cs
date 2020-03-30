using System.ComponentModel.DataAnnotations.Schema;

namespace LearningDataStorage
{
    /// <summary>
    /// Цитата.
    /// </summary>
    [NotMapped]
    public abstract class Quote : IQuote
    {
        public int Id { get; set; }

        /// <summary>
        /// Текст цитаты.
        /// </summary>
        public string Text { get; set; }
    }
}
