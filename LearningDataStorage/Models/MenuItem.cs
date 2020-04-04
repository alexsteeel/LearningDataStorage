using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace LearningDataStorage
{
    public class MenuItem : INotifyPropertyChanged, IInitialized
    {
        public MenuItem(string name, IInitialized viewModel)
        {
            Name = name;
            ViewModel = viewModel;
        }

        public void Init()
        {
            ViewModel.Init();
        }

        public string Name { get; set; }

        public IInitialized ViewModel { get; set; }

        public ScrollBarVisibility HorizontalScrollBarVisibilityRequirement { get; set; }

        public ScrollBarVisibility VerticalScrollBarVisibilityRequirement { get; set; }

        public Thickness MarginRequirement { get; set; } = new Thickness(16);

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
