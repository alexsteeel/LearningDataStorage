using System;
using System.Collections.Generic;
using System.Text;

namespace LearningDataStorage
{
    public class Book
    {
        public int Id { get; set; }

        /// <summary>
        /// Заглавие.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Перевод заглавия.
        /// </summary>
        public string TranslatedTitle { get; set; }

        /// <summary>
        /// Автор.
        /// </summary>
        public ICollection<Author> Authors { get; set; }
    }
}
