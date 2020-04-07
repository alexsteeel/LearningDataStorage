using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningDataStorage.DAL
{
    /// <summary>
    /// Категория книги.
    /// </summary>
    [Table("BookCategories", Schema = "dt")]
    public class BookCategory
    {
        /// <summary>
        /// Идентификатор цитаты.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Номер страницы.
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Id цитируемого издания.
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Цитируемая книга.
        /// </summary>
        public virtual Book Book { get; set; }

        /// <summary>
        /// Заметки.
        /// </summary>
        public ICollection<Note> Notes { get; set; }
    }
}
