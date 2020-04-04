using System;
using System.ComponentModel.DataAnnotations;

namespace LearningDataStorage.DAL
{
    /// <summary>
    /// Файл.
    /// </summary>
    public class FileDescription
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Имя файла.
        /// </summary>
        [Required]
        public string FileName { get; set; }
        
        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Дата и время создания.
        /// </summary>
        public DateTime CreatedTimestamp { get; set; }

        /// <summary>
        /// Дата и время изменения.
        /// </summary>
        public DateTime UpdatedTimestamp { get; set; }
        
        /// <summary>
        /// Тип содержимого.
        /// </summary>
        public string ContentType { get; set; }
    }
}
