using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningDataStorage
{
    /// <summary>
    /// Язык.
    /// </summary>
    [Table("Languages", Schema = "srv")]
    public class Language
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Код языка по ISO 639.
        /// </summary>
        [Required]
        [MaxLength(3)]
        public string Code { get; set; }
    }
}
