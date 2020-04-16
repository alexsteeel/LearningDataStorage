using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningDataStorage.DAL
{
    /// <summary>
    /// Автор.
    /// </summary>
    [Table("Authors", Schema = "dt")]
    public class Author : IHasPhoto<AuthorPhoto>
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
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Отчество.
        /// </summary>
        [MaxLength(100)]
        public string Patronymic { get; set; }

        /// <summary>
        /// Фотографии.
        /// </summary>
        public ICollection<AuthorPhoto> Photo { get; set; }

        /// <summary>
        /// Биография.
        /// </summary>
        public string Biography { get; set; }

    }
}
