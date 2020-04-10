using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningDataStorage.DAL
{
    /// <summary>
    /// Город.
    /// </summary>
    [Table("Cities", Schema = "srv")]
    public class City
    {
        public City()
        {
        }

        public City(int id, string name, int countryId)
        {
            Id = id;
            Name = name;
            CountryId = countryId;
        }

        public City(string name, int countryId)
        {
            Name = name;
            CountryId = countryId;
        }

        /// <summary>
        /// Идентификатор города.
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
        /// Id страны.
        /// </summary>
        public int CountryId { get; set; }

        /// <summary>
        /// Страна.
        /// </summary>
        public virtual Country Country { get; set; }
    }
}
