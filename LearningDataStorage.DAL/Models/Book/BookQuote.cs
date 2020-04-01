using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningDataStorage.DAL
{
    /// <summary>
    /// Цитата из книги.
    /// </summary>
    [Table("BookQuotes", Schema = "dt")]
    public class BookQuote : Quote
    {
        /// <summary>
        /// Номер страницы.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Id цитируемого издания.
        /// </summary>
        public int BookEditionId { get; set; }

        /// <summary>
        /// Цитируемое издание.
        /// </summary>
        public virtual BookEdition BookEdition { get; set; }

        /// <summary>
        /// Заметки.
        /// </summary>
        public ICollection<Note> Notes { get; set; }
    }
}
