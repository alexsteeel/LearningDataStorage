using LearningDataStorage.DAL;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;

namespace LearningDataStorage
{
    public class BookViewModel : BindableBase
    {
        public BookViewModel()
        {
            using (ApplicationContext ctx = new ApplicationContext())
            {
                Books = ctx.Books.ToList();
            }
        }

        /// <summary>
        /// Книги.
        /// </summary>
        public List<Book> Books { get; set; }
    }
}
