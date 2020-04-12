using log4net;
using MaterialDesignThemes.Wpf;
using System.Windows;

namespace LearningDataStorage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Snackbar Snackbar;

        public MainWindow(ILog log, ResourceDictionary localization)
        {
            InitializeComponent();

            var vm = new MainViewModel(MainSnackbar.MessageQueue, log, localization);
            DataContext = vm;

            Snackbar = this.MainSnackbar;
        }
    }
}
