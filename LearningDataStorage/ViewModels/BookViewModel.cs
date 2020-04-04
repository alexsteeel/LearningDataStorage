using LearningDataStorage.DAL;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningDataStorage
{
    public class BookViewModel : BindableBase, IInitialized
    {
        public BookViewModel()
        {
            Books = new List<Book>();
        }

        /// <summary>
        /// Книги.
        /// </summary>
        public List<Book> Books { get; set; }

        public async void Init()
        {
            await Task.Run(() =>
            {
                using (ApplicationContext ctx = new ApplicationContext())
                {
                    Books = ctx.Books.ToList();
                }
            });            
        }
    }
}
