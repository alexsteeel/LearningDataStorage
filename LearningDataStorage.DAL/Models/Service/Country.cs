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
        public Country(int id, string name, string alpha3Code)
        {
            Id = id;
            Name = name;
            Alpha3Code = alpha3Code;
            Cities = new List<City>();
        }
        
        public Country(string name, string alpha3Code)
        {
            Name = name;
            Alpha3Code = alpha3Code;
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
        /// Alpha-3 код.
        /// </summary>
        [Required]
        [MaxLength(3)]
        public string Alpha3Code { get; set; }

        /// <summary>
        /// Города.
        /// </summary>
        public ICollection<City> Cities { get; set; }
    }
}
