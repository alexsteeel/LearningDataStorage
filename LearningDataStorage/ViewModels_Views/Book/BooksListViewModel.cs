using LearningDataStorage.Core.Models;
using LearningDataStorage.Core.Services;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;

namespace LearningDataStorage
{
    public class BooksListViewModel : BaseViewModel, IInitialized
    {
        private readonly IBookServicesContainer _bookContainer;
        private readonly ICommonServicesContainer _commonContainer;

        private readonly IService<Book> _bookService;

        public BooksListViewModel(ISingletonContainer mainContainer,
                                  IBookServicesContainer bookContainer,
                                  ICommonServicesContainer commonContainer)
            : base (mainContainer)
        {
            _bookContainer = bookContainer;
            _commonContainer = commonContainer;

            _bookService = bookContainer.BookService;            

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
            CreateBookEditViewModel(SelectedBook);
        }

        private void AddBook()
        {
            CreateBookEditViewModel(null);
        }

        private void CreateBookEditViewModel(Book book)
        {
            SelectedBookViewModel = new BookEditViewModel(_mainContainer, _bookContainer, _commonContainer, book);
            SelectedBookViewModel.OnAccepted += SelectedBookViewModel_IsAccepted;
            SelectedBookViewModel.OnCanceled += SelectedBookViewModel_IsCanceled;
            IsBookOpen = true;
        }

        #endregion Methods
    }
}
