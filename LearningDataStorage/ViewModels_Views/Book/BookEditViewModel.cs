using LearningDataStorage.DAL;
using log4net;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace LearningDataStorage
{
    public class BookEditViewModel : BindableBase, IDialogPage
    {
        private readonly ILog _log;
        private readonly ResourceDictionary _localization;

        public BookEditViewModel(Book book, ILog log, ResourceDictionary localization)
        {
            _log = log;
            _localization = localization;

            PrepareBook(book);
            GetCollections();

            SaveCommand = new DelegateCommand(SaveChanges, CanSaveChanges);
            LoadBookCoverCommand = new DelegateCommand(LoadBookCover);
            CancelCommand = new DelegateCommand(Cancel);
        }

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
                _log.Error($"{_localization["m_Er_LoadDataError"]}{_localization["m_Er_DetailedError"]}", ex);
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

        #region Properties

        public ICollection<Language> Languages { get; set; }

        public ICollection<PublishingHouse> PublishingHouses { get; set; }

        public ICollection<City> Cities { get; set; }

        #endregion Properties

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
                _log.Error($"{_localization["m_Er_SaveBooksError"]}{_localization["m_Er_DetailedError"]}", ex);
            }            
        }

        private void Cancel()
        {
            OnCanceled?.Invoke(this, EventArgs.Empty);
        }

        public Book Book { get; set; }

        public bool IsEditMode { get; set; }

        public DelegateCommand SaveCommand { get; set; }

        public DelegateCommand CancelCommand { get; set; }

        public event EventHandler OnAccepted;

        public event EventHandler OnCanceled;

        public DelegateCommand LoadBookCoverCommand { get; set; }

        
        private void LoadBookCover()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var fileLoader = new FileLoader();
                fileLoader.LoadBookCover(openFileDialog.FileName, Book.Id);
            }
        }
    }
}
