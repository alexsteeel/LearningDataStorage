using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningDataStorage.DAL
{
    /// <summary>
    /// Издательство.
    /// </summary>
    [Table("PublishingHouses", Schema = "dt")]
    public class PublishingHouse
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        [Required]
        [MaxLength(500)]
        public string Title { get; set; }
    }
}
