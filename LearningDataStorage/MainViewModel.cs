using log4net;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace LearningDataStorage
{
    public class MainViewModel : BindableBase
    {
        private readonly ILog _log;
        private readonly ResourceDictionary _localization;

        public MainViewModel(ISnackbarMessageQueue snackbarMessageQueue, ILog log, ResourceDictionary localization)
        {
            _log = log;
            _localization = localization;

            CloseCommand = new DelegateCommand(Close);

            try
            {
                Items = GenerateMenuItems(snackbarMessageQueue);
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

        private ObservableCollection<MenuItem> GenerateMenuItems(ISnackbarMessageQueue snackbarMessageQueue)
        {
            if (snackbarMessageQueue == null)
            {
                throw new ArgumentNullException(nameof(snackbarMessageQueue)); 
            }

            return new ObservableCollection<MenuItem>
            {
                new MenuItem(_localization["m_Sc_Books"].ToString(), new BooksListViewModel(_log, _localization)),
                new MenuItem(_localization["m_Sc_Cities"].ToString(), new CitiesListViewModel(_log, _localization))
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
