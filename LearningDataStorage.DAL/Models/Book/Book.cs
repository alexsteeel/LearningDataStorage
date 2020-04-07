using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

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
        /// Авторы.
        /// </summary>
        public ICollection<Author> Authors { get; set; }

        /// <summary>
        /// Обложка.
        /// </summary>
        public BookCover BookCover { get; set; }

        /// <summary>
        /// Заглавие.
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
        /// Id языка.
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// Язык.
        /// </summary>
        public virtual Language Language { get; set; }

        /// <summary>
        /// Id издательства.
        /// </summary>
        public int PublishingHouseId { get; set; }

        /// <summary>
        /// Издательство.
        /// </summary>
        public virtual PublishingHouse PublishingHouse { get; set; }

        private int _year;
        /// <summary>
        /// Год издания.
        /// </summary>
        public int Year
        {
            get { return _year; }
            set
            {
                if (value < 1445)
                {
                    throw new FormatException("Указан год издания меньше, чем год изобретения книгопечатания в Европе.");
                }
                else if (value > DateTime.Now.Year)
                {
                    throw new FormatException("Указан год издания, который еще не наступил.");
                }
                else
                {
                    _year = value;
                }
            }
        }

        /// <summary>
        /// Id города издания.
        /// </summary>
        public int CityId { get; set; }

        /// <summary>
        /// Город издания.
        /// </summary>
        public City City { get; set; }

        /// <summary>
        /// Количество страниц.
        /// </summary>
        public int PagesCount { get; set; }       

        /// <summary>
        /// Оценки книги.
        /// </summary>
        public ICollection<BookRating> Ratings { get; set; }

        /// <summary>
        /// Цитаты.
        /// </summary>
        public ICollection<BookQuote> Quotes { get; set; }

        /// <summary>
        /// Заметки.
        /// </summary>
        public ICollection<Note> Notes { get; set; }

    }
}
