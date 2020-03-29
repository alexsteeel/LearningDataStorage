using System.ComponentModel.DataAnnotations;

namespace LearningDataStorage
{
    /// <summary>
    /// Язык.
    /// </summary>
    public class Language
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Код языка по ISO 639.
        /// </summary>
        [MaxLength(3)]
        public string Code { get; set; }
    }
}
