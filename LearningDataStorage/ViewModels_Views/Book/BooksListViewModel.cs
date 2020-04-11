﻿using LearningDataStorage.DAL;
using log4net;
using Microsoft.EntityFrameworkCore;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LearningDataStorage
{
    public class BooksListViewModel : BindableBase, IInitialized
    {
        private readonly ILog _log;
        private readonly ResourceDictionary _localization;

        public BooksListViewModel(ILog log, ResourceDictionary localization)
        {
            _log = log;
            _localization = localization;

            Books = new List<Book>();
            ShowBookCommand = new DelegateCommand(ShowBook);
            AddBookCommand = new DelegateCommand(AddBook);
        }

        public DelegateCommand ShowBookCommand { get; set; }

        public DelegateCommand AddBookCommand { get; set; }

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

        public bool IsLoading { get; set; }

        #endregion Properties


        #region Methods

        public async void Init()
        {
            IsLoading = true;
            try
            {                
                await Task.Run(() =>
                {
                    using (ApplicationContext ctx = new ApplicationContext())
                    {
                        Books = ctx.Books
                                .Include(book => book.BookCover)
                                    .ThenInclude(cover => cover.File)
                                .Include(book => book.PublishingHouse)
                                .Include(book => book.City)
                                .Include(book => book.Language)
                                .Include(book => book.Authors)
                                .Include(book => book.Ratings)
                                    .ThenInclude(rating => rating.Site)
                                .ToList();
                    }
                });

                IsBookOpen = true;
            }
            catch (Exception ex)
            {
                _log.Error($"{_localization["m_Er_InitBooksError"]}{_localization["m_Er_DetailedError"]}", ex);
            }
            finally
            {
                IsLoading = false;
            }
        }

        private void ShowBook()
        {
            SelectedBookViewModel = new BookEditViewModel(SelectedBook, _log, _localization);
            SelectedBookViewModel.OnAccepted += SelectedBookViewModel_IsAccepted;
            SelectedBookViewModel.OnCanceled += SelectedBookViewModel_IsCanceled;
            IsBookOpen = true;
        }

        private void AddBook()
        {
            SelectedBookViewModel = new BookEditViewModel(null, _log, _localization);
            SelectedBookViewModel.OnAccepted += SelectedBookViewModel_IsAccepted;
            SelectedBookViewModel.OnCanceled += SelectedBookViewModel_IsCanceled;
            IsBookOpen = true;
        }

        #endregion Methods
    }
}
