using System.Windows;
using System.Windows.Controls;

namespace LearningDataStorage
{
    public partial class CountriesListView : UserControl
    {
        public CountriesListView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Focus();
        }
    }
}
