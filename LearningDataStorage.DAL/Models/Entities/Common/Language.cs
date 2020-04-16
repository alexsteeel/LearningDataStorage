using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningDataStorage.DAL
{
    /// <summary>
    /// Язык.
    /// </summary>
    [Table("Languages", Schema = "srv")]
    public class Language
    {
        public Language(int id, string name, string code)
        {
            Id = id;
            Name = name;
            Code = code;
        }

        public Language(string name, string code)
        {
            Name = name;
            Code = code;
        }

        /// <summary>
        /// Идентификатор языка.
        /// </summary>
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
