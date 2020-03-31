using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningDataStorage
{
    /// <summary>
    /// Фотография автора.
    /// </summary>
    [Table("AuthorPhoto", Schema = "file")]
    public class AuthorPhoto : IPhoto
    {
        /// <summary>
        /// Guid файла из файловой таблицы.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid StreamId { get; set; }

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
