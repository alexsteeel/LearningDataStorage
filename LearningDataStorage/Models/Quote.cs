using System.Collections.Generic;

namespace LearningDataStorage
{
    /// <summary>
    /// Цитата.
    /// </summary>
    public class Quote : IQuote
    {
        public int Id { get; set; }

        /// <summary>
        /// Страница.
        /// </summary>
        public int Page { get; set; }

        /// <summary>
        /// Текст цитаты.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Id цитируемого объекта.
        /// </summary>
        public int QuotedObjectId { get; set; }

        /// <summary>
        /// Цитируемый объект.
        /// </summary>
        public virtual IHasQuotes QuotedObject { get; set; }

        /// <summary>
        /// Заметки.
        /// </summary>
        public ICollection<Note> Notes { get; set; }
    }
}
