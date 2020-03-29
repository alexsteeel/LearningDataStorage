using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningDataStorage
{
    /// <summary>
    /// Заметка.
    /// </summary>
    [Table("Notes", Schema = "dt")]
    public class Note
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Дата создания/изменения.
        /// </summary>
        public DateTime ChangeDate { get; set; }

        /// <summary>
        /// Текст заметки.
        /// </summary>
        public string Text { get; set; }
    }
}