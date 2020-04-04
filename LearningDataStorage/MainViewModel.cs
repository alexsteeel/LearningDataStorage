using MaterialDesignThemes.Wpf;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace LearningDataStorage
{
    public class MainViewModel : BindableBase
    {
        public MainViewModel(ISnackbarMessageQueue snackbarMessageQueue)
        {
            Items = GenerateMenuItems(snackbarMessageQueue);
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

        private ObservableCollection<MenuItem> GenerateMenuItems(ISnackbarMessageQueue snackbarMessageQueue)
        {
            if (snackbarMessageQueue == null)
                throw new ArgumentNullException(nameof(snackbarMessageQueue));

            return new ObservableCollection<MenuItem>
            {
                new MenuItem("Books", new BookViewModel())
            };
        }

        public bool IsChecked { get; set; } = false;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
