using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace LearningDataStorage
{
    /// <summary>
    /// Издание книги.
    /// </summary>
    [Table("BookEditions", Schema = "dt")]
    public class BookEdition : IHasQuotes<Quote>
    {
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Обложка.
        /// </summary>
        public BookCover BookCover { get; set; }

        /// <summary>
        /// Заглавие (здесь в отличие от самой книги может быть переведенный вариант).
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Id языка.
        /// </summary>
        [Required]
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

        private string _ISBN;
        /// <summary>
        /// Международный стандартный номер книги.
        /// International Standard Book Number.
        /// </summary>
        public string ISBN
        {
            get { return _ISBN; }
            set
            {
                string pattern = @"(\d{10,13}).*?_(\d{3})|(\d{3}).*?_(\d{10,13})|(\d{10,13})(?=[^\d])";
                var regex = new Regex(pattern);
                if (regex.IsMatch(value))
                {
                    _ISBN = value;
                }
                else
                {
                    throw new FormatException("Указанный стандартный номер книги не соответствует шаблону.");
                }
            }
        }

        /// <summary>
        /// Цитаты.
        /// </summary>
        public ICollection<Quote> Quotes { get; set; }

        /// <summary>
        /// Заметки.
        /// </summary>
        public ICollection<Note> Nptes { get; set; }
    }
}
