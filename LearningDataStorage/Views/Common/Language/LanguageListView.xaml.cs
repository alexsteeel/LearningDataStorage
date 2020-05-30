using System.Windows;
using System.Windows.Controls;

namespace LearningDataStorage
{
    public partial class LanguageListView : UserControl
    {
        public LanguageListView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Focus();
        }
    }
}
