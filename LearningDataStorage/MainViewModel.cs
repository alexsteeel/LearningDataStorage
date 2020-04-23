using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace LearningDataStorage
{
    public class MainViewModel : BaseViewModel
    {
        private readonly IBookServicesContainer _bookContainer;
        private readonly ICommonServicesContainer _servicesContainer;

        public MainViewModel(ISingletonContainer mainContainer,
                             IBookServicesContainer bookContainer,
                             ICommonServicesContainer servicesContainer)
            : base (mainContainer)
        {
            _bookContainer = bookContainer;
            _servicesContainer = servicesContainer;

            CloseCommand = new DelegateCommand(Close);

            try
            {
                Items = GenerateMenuItems();
            }
            catch (Exception ex)
            {
                _log.Error($"{_localization["m_Er_InitMainMenuError"]}{_localization["m_Er_DetailedError"]}", ex);
            }            
        }

        public ObservableCollection<MenuItem> Items { get; set; }

        private MenuItem _selectedItem;
        public MenuItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                IsChecked = false;

                if (value == null || value.Equals(_selectedItem))
                {
                    return;
                }

                _selectedItem = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedItem)));
                SelectedItem.Init();
            }
        }

        public DelegateCommand CloseCommand { get; private set; }

        private ObservableCollection<MenuItem> GenerateMenuItems()
        {
            return new ObservableCollection<MenuItem>
            {
                new MenuItem(_localization["m_Sc_Books"].ToString(), new BooksListViewModel(_mainContainer, _bookContainer, _servicesContainer)),
                new MenuItem(_localization["m_Sc_Cities"].ToString(), new CitiesListViewModel(_mainContainer, _servicesContainer)),
                new MenuItem(_localization["m_Sc_Countries"].ToString(), new CountriesListViewModel(_mainContainer, _servicesContainer))
            };
        }

        private void Close()
        {
            Environment.Exit(0);
        }

        public bool IsChecked { get; set; } = false;

        public new event PropertyChangedEventHandler PropertyChanged;
    }
}
