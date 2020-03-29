using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningDataStorage
{
    /// <summary>
    /// Город.
    /// </summary>
    [Table("Cities", Schema = "srv")]
    public class City
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
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
