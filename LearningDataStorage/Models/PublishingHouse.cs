using System.ComponentModel.DataAnnotations;

namespace LearningDataStorage
{
    /// <summary>
    /// Издательство.
    /// </summary>
    public class PublishingHouse
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        public string Title { get; set; }
    }
}
