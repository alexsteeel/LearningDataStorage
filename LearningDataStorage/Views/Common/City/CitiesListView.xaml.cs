using System.Windows;
using System.Windows.Controls;

namespace LearningDataStorage
{
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
