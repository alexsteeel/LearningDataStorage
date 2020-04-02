using Prism.Mvvm;

namespace LearningDataStorage
{
    public class MainViewModel : BindableBase
    {
        public MainViewModel()
        {
            CurrentViewModel = new BookViewModel();
        }

        public BindableBase CurrentViewModel { get; set; }

    }
}
