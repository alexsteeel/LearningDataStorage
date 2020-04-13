using log4net;
using MaterialDesignThemes.Wpf;
using System;
using System.Windows;
using System.Windows.Input;

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

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            MaximizeToggle();
        }

        private void ColorZone_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MaximizeToggle();
        }

        private void ColorZone_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void MaximizeToggle()
        {
            if (WindowState.ToString() == "Normal")
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }
    }
}
