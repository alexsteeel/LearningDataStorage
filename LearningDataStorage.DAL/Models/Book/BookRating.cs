using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningDataStorage.DAL
{
    /// <summary>
    /// Оценка книги.
    /// </summary>
    [Table("BookRatings", Schema = "dt")]
    public class BookRating
    {
        public BookRating(int siteId, decimal maxValue, decimal value)
        {
            SiteId = siteId;
            MaxValue = maxValue;
            Value = value;
        }

        /// <summary>
        /// Идентификатор оценки книги.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор сайта.
        /// </summary>
        public int SiteId { get; set; }

        /// <summary>
        /// Сайт, на котором выставлена оценка.
        /// </summary>
        public virtual Site Site { get; set; }

        /// <summary>
        /// Максимально возможная оценка.
        /// </summary>
        public decimal MaxValue { get; set; }

        private decimal _value;
        /// <summary>
        /// Оценка.
        /// </summary>
        public decimal Value
        {
            get { return _value;  }
            set
            {
                if (value > MaxValue)
                {
                    _value = MaxValue;
                }
                else
                {
                    _value = value;
                }
            }
        }

        /// <summary>
        /// Оценка в процентах.
        /// </summary>
        [NotMapped]
        public decimal ValuePercent 
        {
            get
            {
                if (MaxValue == 0)
                {
                    return 0;
                }
                else
                {
                    return Value / MaxValue * 100;
                }
            }
        }
    }
}
