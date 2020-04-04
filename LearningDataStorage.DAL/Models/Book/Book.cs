using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningDataStorage.DAL
{
    /// <summary>
    /// Книги.
    /// </summary>
    [Table("Books", Schema = "dt")]
    public class Book
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Заглавие. Здесь используется оригинальное заглавие книги на том языке,
        /// на котором она была изначально опубликована.
        /// Для хранения информации о других изданиях используется класс BookEdition.
        /// </summary>
        [Required]
        [MaxLength(500)]
        public string Title { get; set; }

        /// <summary>
        /// Краткое описание.
        /// </summary>
        [Required]
        [MaxLength(1000)]
        public string ShortDescription { get; set; }

        /// <summary>
        /// Авторы.
        /// </summary>
        public ICollection<Author> Authors { get; set; }

        /// <summary>
        /// Издания.
        /// </summary>
        public ICollection<BookEdition> BookEditions { get; set; }

        /// <summary>
        /// Оценки книги.
        /// </summary>
        public ICollection<BookRating> BookRatings { get; set; }

    }
}
