using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningDataStorage.DAL
{
    /// <summary>
    /// Ссылка.
    /// </summary>
    [Table("Links", Schema = "dt")]
    public class Link
    {
        /// <summary>
        /// Идентификатор ссылки.
        /// </summary>
        [Key]
        public int Id { get; set; }
        
        /// <summary>
        /// Путь.
        /// </summary>
        [Required]
        [MaxLength(1000)]
        public string Path { get; set; }
    }
}
