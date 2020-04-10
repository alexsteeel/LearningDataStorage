using System.Windows;
using System.Windows.Controls;

namespace LearningDataStorage
{
    /// <summary>
    /// Interaction logic for BookView.xaml
    /// </summary>
    public partial class CitiesListView : UserControl
    {
        public CitiesListView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Focus();
        }
    }
}
