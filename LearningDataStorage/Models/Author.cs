using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningDataStorage
{
    /// <summary>
    /// Автор.
    /// </summary>
    [Table("Authors", Schema = "dt")]
    public class Author : IHasPhoto<Photo>
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Фамилия.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Surname { get; set; }

        /// <summary>
        /// Имя.
        /// </summary>
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        [MaxLength(100)]
        public string Patronymic { get; set; }

        /// <summary>
        /// Фотографии.
        /// </summary>
        public ICollection<Photo> Photo { get; set; }

        /// <summary>
        /// Биография.
        /// </summary>
        public string Biography { get; set; }

    }
}
