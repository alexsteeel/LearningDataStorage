using LearningDataStorage.Core.Models;
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
        public BookEditViewModel(IMainContainer mainContainer, Book book)
            : base (mainContainer)
        {
            PrepareBook(book);
            GetCollections();

            SaveCommand = new DelegateCommand(SaveChanges, CanSaveChanges);
            LoadBookCoverCommand = new DelegateCommand(LoadBookCover);
            CancelCommand = new DelegateCommand(Cancel);
        }

        #region Properties

        public Book Book { get; set; }

        public bool IsEditMode { get; set; }

        public ICollection<Language> Languages { get; set; }

        public ICollection<PublishingHouse> PublishingHouses { get; set; }

        public ICollection<City> Cities { get; set; }

        #endregion Properties

        #region Commands

        public DelegateCommand SaveCommand { get; set; }

        public DelegateCommand CancelCommand { get; set; }

        public DelegateCommand LoadBookCoverCommand { get; set; }

        #endregion Commands

        #region Methods

        private void GetCollections()
        {
            try
            {
                using ApplicationContext ctx = new ApplicationContext();
                Languages = ctx.Languages.ToList();
                PublishingHouses = ctx.PublishingHouses.ToList();
                Cities = ctx.Cities.ToList();
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

        private void SaveChanges()
        {
            try
            {
                using ApplicationContext ctx = new ApplicationContext();
                var book = ctx.Books.FirstOrDefault(x => x.Id == Book.Id);
                if (book == null)
                {
                    ctx.Books.Add(Book);
                }
                else
                {
                    ctx.Entry(book).CurrentValues.SetValues(Book);
                }

                ctx.SaveChanges();
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
