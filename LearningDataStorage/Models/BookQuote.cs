using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningDataStorage
{
    /// <summary>
    /// Цитата.
    /// </summary>
    [Table("BookQuotes", Schema = "dt")]
    public class BookQuote : IQuote
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Номер страницы.
        /// </summary>
        public int PageNumber { get; set; }

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
        public virtual IHasQuotes<IQuote> QuotedObject { get; set; }

        /// <summary>
        /// Заметки.
        /// </summary>
        public ICollection<Note> Notes { get; set; }
    }
}
