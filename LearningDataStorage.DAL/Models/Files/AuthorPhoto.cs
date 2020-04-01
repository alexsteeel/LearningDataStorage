using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningDataStorage.DAL
{
    /// <summary>
    /// Фотография автора.
    /// </summary>
    [Table("AuthorPhoto", Schema = "file")]
    public class AuthorPhoto : IPhoto
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Id файла.
        /// </summary>
        public int FileId { get; set; }

        /// <summary>
        /// Id автора.
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// Автор.
        /// </summary>
        public virtual Author Author { get; set; }
    }
}
