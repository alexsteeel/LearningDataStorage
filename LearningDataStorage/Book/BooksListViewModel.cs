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
    public class BooksListViewModel : BindableBase, IInitialized
    {
        public BooksListViewModel()
        {
            Books = new List<Book>();
            ShowBookCommand = new DelegateCommand(ShowBook);
        }

        public DelegateCommand ShowBookCommand { get; set; }
        
        private void SelectedBookViewModel_IsAccepted(object sender, EventArgs e)
        {
            IsBookOpen = false;
        }

        private void SelectedBookViewModel_IsCanceled(object sender, EventArgs e)
        {
            IsBookOpen = false;
        }        


        #region Properties

        public List<Book> Books { get; set; }

        public Book SelectedBook { get; set; }

        public IDialog SelectedBookViewModel { get; set; }
        
        public bool IsBookOpen { get; set; }

        #endregion Properties


        #region Methods

        public async void Init()
        {
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
        }

        private void ShowBook()
        {
            SelectedBookViewModel = new BookEditViewModel(SelectedBook);
            SelectedBookViewModel.OnAccepted += SelectedBookViewModel_IsAccepted;
            SelectedBookViewModel.OnCanceled += SelectedBookViewModel_IsCanceled;
            IsBookOpen = true;
        }

        #endregion Methods
    }
}
