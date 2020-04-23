using LearningDataStorage.Core.Models;
using LearningDataStorage.Core.Services;
using LearningDataStorage.DAL;
using log4net;
using Microsoft.Win32;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace LearningDataStorage
{
    public class BookEditViewModel : BaseViewModel, IDialogPage
    {

        private readonly IService<Book> _bookService;
        private readonly IService<PublishingHouse> _publishingHouseService;

        private readonly IService<City> _cityService;
        private readonly IService<Country> _countryService;
        private readonly IService<Language> _languageService;

        public BookEditViewModel(ISingletonContainer mainContainer,
                                 IBookServicesContainer bookContainer,
                                 ICommonServicesContainer commonContainer,
                                 Book book)
            : base (mainContainer)
        {
            _bookService = bookContainer.BookService;
            _publishingHouseService = bookContainer.PublishingHouseService;

            _cityService = commonContainer.CityService;
            _countryService = commonContainer.CountryService;
            _languageService = commonContainer.LanguageService;

            PrepareBook(book);
            SetCollections();

            SaveCommand = new DelegateCommand(SaveChanges, CanSaveChanges);
            LoadBookCoverCommand = new DelegateCommand(LoadBookCover);
            CancelCommand = new DelegateCommand(Cancel);
        }

        #region Properties

        public Book Book { get; set; }

        public bool IsEditMode { get; set; }

        public IEnumerable<Language> Languages { get; set; }

        public IEnumerable<PublishingHouse> PublishingHouses { get; set; }

        public IEnumerable<City> Cities { get; set; }

        #endregion Properties

        #region Commands

        public DelegateCommand SaveCommand { get; set; }

        public DelegateCommand CancelCommand { get; set; }

        public DelegateCommand LoadBookCoverCommand { get; set; }

        #endregion Commands

        #region Methods

        private async void SetCollections()
        {
            try
            {
                Languages = await _languageService.GetAll();
                PublishingHouses = await _publishingHouseService.GetAll();
                Cities = await _cityService.GetAll();
            }
            catch (Exception ex)
            {
                var errorText = $"{_localization["m_Er_LoadDataError"]}{_localization["m_Er_DetailedError"]}";
                _log.Error(errorText, ex);
                _dialog.Error($"{errorText} {ex.Message}");
            }
        }

        private void PrepareBook(Book book)
        {
            if (book == null)
            {
                Book = new Book
                {
                    Year = 2020
                };
            }
            else
            {
                Book = book;
            }
        }

        private bool CanSaveChanges()
        {
            return true;
        }

        private async void SaveChanges()
        {
            try
            {
                if (Book.Id != 0)
                {
                    var book = await _bookService.GetById(Book.Id);
                    await _bookService.Update(book, Book);
                }
                else
                {
                    await _bookService.Create(Book);
                }
            }
            catch (Exception ex)
            {
                var errorText = $"{_localization["m_Er_SaveBooksError"]}{_localization["m_Er_DetailedError"]}";
                _log.Error(errorText, ex);
                _dialog.Error($"{errorText} {ex.Message}");
            }            
        }

        private void Cancel()
        {
            OnCanceled?.Invoke(this, EventArgs.Empty);
        }

        private void LoadBookCover()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                // TODO: add loading of book cover.
                //var fileLoader = new FileLoader();
                //fileLoader.LoadBookCover(openFileDialog.FileName, Book.Id);
            }
        }

        #endregion Methods

        public event EventHandler OnAccepted;

        public event EventHandler OnCanceled;

    }
}
