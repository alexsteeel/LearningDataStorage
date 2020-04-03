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

        public MainWindow()
        {
            InitializeComponent();

            var vm = new MainViewModel(MainSnackbar.MessageQueue);
            DataContext = vm;

            Snackbar = this.MainSnackbar;
        }
    }
}
