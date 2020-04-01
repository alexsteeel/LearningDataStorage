using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningDataStorage.DAL
{
    /// <summary>
    /// Обложка книги.
    /// </summary>
    [Table("BookCovers", Schema = "file")]
    public class BookCover
    {
        public BookCover(int fileId, int bookEditionId)
        {
            FileId = fileId;
            BookEditionId = bookEditionId;
        }

        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Id файла.
        /// </summary>
        [Required]
        public int FileId { get; set; }

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
