using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningDataStorage
{
    /// <summary>
    /// Страна.
    /// </summary>
    [Table("Countries", Schema = "srv")]
    public class Country
    {
        public Country()
        {
            Cities = new List<City>();
        }

        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Города.
        /// </summary>
        public ICollection<City> Cities { get; set; }
    }
}
