using LearningDataStorage.DAL;
using Prism.Mvvm;
using System;
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

        public bool IsEnabled { get; set; }

        public async void Init()
        {
            IsEnabled = false;

            try
            {
                await Task.Run(() =>
                {
                    using (ApplicationContext ctx = new ApplicationContext())
                    {
                        Books = ctx.Books.ToList();
                    }
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                IsEnabled = true;
            }                        
        }
    }
}
