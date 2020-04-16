using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningDataStorage.DAL
{
    /// <summary>
    /// Сайт.
    /// </summary>
    [Table("Sites", Schema = "dt")]
    public class Site
    {
        public Site(string title, string description, int mainPageLinkId)
        {
            Title = title;
            Description = description;
            MainPageLinkId = mainPageLinkId;
        }

        /// <summary>
        /// Идентификатор сайта.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Наименование.
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Идентификатор ссылки на главную страницу.
        /// </summary>
        public int MainPageLinkId { get; set; }

        /// <summary>
        /// Ссылка на главную страницу.
        /// </summary>
        [ForeignKey("MainPageLinkId")]
        public virtual Link MainPageLink { get; set; }
        
    }
}
