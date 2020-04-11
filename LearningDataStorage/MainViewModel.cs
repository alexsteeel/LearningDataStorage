using log4net;
using log4net.Config;
using MaterialDesignThemes.Wpf;
using Prism.Mvvm;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;

namespace LearningDataStorage
{
    public class MainViewModel : BindableBase
    {
        private readonly ILog _log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        private readonly ResourceDictionary _localization;

        public MainViewModel(ISnackbarMessageQueue snackbarMessageQueue)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            _localization = Application.Current.Resources.MergedDictionaries
               .Where(x => x.Source.OriginalString.Contains("Localizations/lang"))
               .FirstOrDefault();

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

        private ObservableCollection<MenuItem> GenerateMenuItems(ISnackbarMessageQueue snackbarMessageQueue)
        {
            if (snackbarMessageQueue == null)
                throw new ArgumentNullException(nameof(snackbarMessageQueue));

            return new ObservableCollection<MenuItem>
            {
                new MenuItem(_localization["m_Sc_Books"].ToString(), new BooksListViewModel(_log, _localization)),
                new MenuItem(_localization["m_Sc_Cities"].ToString(), new CitiesListViewModel(_log, _localization))
            };
        }

        public bool IsChecked { get; set; } = false;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
