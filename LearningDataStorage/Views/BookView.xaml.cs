using System.Windows.Controls;

namespace LearningDataStorage
{
    /// <summary>
    /// Interaction logic for BookView.xaml
    /// </summary>
    public partial class BookView : UserControl
    {
        public BookView()
        {
            InitializeComponent();

            var vm = new BookViewModel();
            DataContext = vm;
        }
    }
}
