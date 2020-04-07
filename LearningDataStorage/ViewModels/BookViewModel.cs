using LearningDataStorage.DAL;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Linq;

namespace LearningDataStorage
{
    public class BookViewModel : BindableBase, IDialog
    {
        public BookViewModel(Book book)
        {
            Book = book;
            SaveCommand = new DelegateCommand(SaveChanges, CanSaveChanges);
            LoadBookCoverCommand = new DelegateCommand(LoadBookCover);
            CancelCommand = new DelegateCommand(Cancel);
        }

        private bool CanSaveChanges()
        {
            return true;
        }

        private void SaveChanges()
        {
            using (ApplicationContext ctx = new ApplicationContext())
            {
                var book = ctx.Books.FirstOrDefault(x => x.Id == Book.Id);
                if (book == null)
                {
                    ctx.Books.Add(book);
                }
                else
                {
                    ctx.Entry(book).CurrentValues.SetValues(Book);
                }

                ctx.SaveChanges();
            }
        }

        private void Cancel()
        {
            IsCanceled?.Invoke(this, EventArgs.Empty);
        }

        public Book Book { get; set; }

        public bool IsEditMode { get; set; }

        public DelegateCommand SaveCommand { get; set; }

        public DelegateCommand CancelCommand { get; set; }

        public event EventHandler IsAccepted;

        public event EventHandler IsCanceled;

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
