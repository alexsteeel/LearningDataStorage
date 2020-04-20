﻿using LearningDataStorage.Core.Models;
using LearningDataStorage.Core.Services;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;

namespace LearningDataStorage
{
    public class BooksListViewModel : BaseViewModel, IInitialized
    {
        private readonly IService<Book> _bookService;

        public BooksListViewModel(ISingletonContainer mainContainer, IServicesContainer servicesContainer)
            : base (mainContainer)
        {
            _bookService = servicesContainer.BookService;

            Books = new ObservableCollection<Book>();
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

        public ObservableCollection<Book> Books { get; set; }

        public Book SelectedBook { get; set; }

        public IDialogPage SelectedBookViewModel { get; set; }
        
        public bool IsBookOpen { get; set; }

        public bool IsLoading { get; set; }

        #endregion Properties


        #region Methods

        public async void Init()
        {
            IsLoading = true;
            try
            {                
                var books = await _bookService.GetAll();
                Books = new ObservableCollection<Book>(books);
                IsBookOpen = true;
            }
            catch (Exception ex)
            {
                var errorText = $"{_localization["m_Er_InitBooksError"]}{_localization["m_Er_DetailedError"]}";
                _log.Error(errorText, ex);
                _dialog.Error($"{errorText} {ex.Message}");
            }
            finally
            {
                IsLoading = false;
            }
        }

        private void ShowBook()
        {
            SelectedBookViewModel = new BookEditViewModel(_mainContainer, SelectedBook);
            SelectedBookViewModel.OnAccepted += SelectedBookViewModel_IsAccepted;
            SelectedBookViewModel.OnCanceled += SelectedBookViewModel_IsCanceled;
            IsBookOpen = true;
        }

        private void AddBook()
        {
            SelectedBookViewModel = new BookEditViewModel(_mainContainer, null);
            SelectedBookViewModel.OnAccepted += SelectedBookViewModel_IsAccepted;
            SelectedBookViewModel.OnCanceled += SelectedBookViewModel_IsCanceled;
            IsBookOpen = true;
        }

        #endregion Methods
    }
}
