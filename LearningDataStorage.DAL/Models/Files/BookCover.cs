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
        public BookCover(int fileId, int bookId)
        {
            FileId = fileId;
            BookId = bookId;
        }

        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Id файла.
        /// </summary>
        [Required]
        public int FileId { get; set; }

        /// <summary>
        /// Файл.
        /// </summary>
        public virtual DbFile File { get; set; }

        /// <summary>
        /// Id издания книги.
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Книга.
        /// </summary>
        public virtual Book Book { get; set; }
    }
}
