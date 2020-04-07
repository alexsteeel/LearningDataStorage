using LearningDataStorage.DAL;
using Microsoft.EntityFrameworkCore;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LearningDataStorage
{
    public class BooksViewModel : BindableBase, IInitialized
    {
        public BooksViewModel()
        {
            Books = new List<Book>();

            ShowBookCommand = new DelegateCommand<object>(ShowBook, CanShowBook);
        }

        private void SelectedBookViewModel_IsCanceled(object sender, EventArgs e)
        {
            IsDialogOpen = false;
        }

        private void SelectedBookViewModel_IsAccepted(object sender, EventArgs e)
        {
            IsDialogOpen = false;
        }

        private bool CanShowBook(object parameter)
        {
            return true;
        }

        private void ShowBook(object parameter)
        {
            SelectedBook = (Book)parameter;
            SelectedBookViewModel = new BookViewModel(SelectedBook);
            SelectedBookViewModel.IsAccepted += SelectedBookViewModel_IsAccepted;
            SelectedBookViewModel.IsCanceled += SelectedBookViewModel_IsCanceled;
            IsDialogOpen = true;
        }

        /// <summary>
        /// Книги.
        /// </summary>
        public List<Book> Books { get; set; }

        /// <summary>
        /// Выбранная книга.
        /// </summary>
        public Book SelectedBook { get; set; }

        public IDialog SelectedBookViewModel { get; set; }
        public bool IsDialogOpen { get; set; }
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
                        Books = ctx.Books
                                .Include(edition => edition.BookCover)
                                    .ThenInclude(cover => cover.File)
                                .Include(edition => edition.PublishingHouse)
                                .Include(edition => edition.City)
                                .Include(edition => edition.Language)
                                .Include(book => book.Authors)
                                .Include(book => book.Ratings)
                                    .ThenInclude(rating => rating.Site)
                                .ToList();
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

        public DelegateCommand<object> ShowBookCommand { get; set; }
    }
}
