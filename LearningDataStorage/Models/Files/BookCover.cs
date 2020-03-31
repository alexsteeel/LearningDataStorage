using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningDataStorage
{
    /// <summary>
    /// Обложка книги.
    /// </summary>
    [Table("BookCovers", Schema = "file")]
    public class BookCover
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid StreamId { get; set; }

        /// <summary>
        /// Id издания книги.
        /// </summary>
        public int BookEditionId { get; set; }

        /// <summary>
        /// Издание книги.
        /// </summary>
        public virtual BookEdition BookEdition { get; set; }
    }
}
