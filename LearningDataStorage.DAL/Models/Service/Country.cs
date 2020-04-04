using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningDataStorage.DAL
{
    /// <summary>
    /// Страна.
    /// </summary>
    [Table("Countries", Schema = "srv")]
    public class Country
    {
        public Country(string name)
        {
            Name = name;
            Cities = new List<City>();
        }

        /// <summary>
        /// Идентификатор страны.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        /// <summary>
        /// Города.
        /// </summary>
        public ICollection<City> Cities { get; set; }
    }
}
