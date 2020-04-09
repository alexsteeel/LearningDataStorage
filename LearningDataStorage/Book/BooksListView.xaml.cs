using System.Windows;
using System.Windows.Controls;

namespace LearningDataStorage
{
    /// <summary>
    /// Interaction logic for BookView.xaml
    /// </summary>
    public partial class BooksListView : UserControl
    {
        public BooksListView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Focus();
        }
    }
}
