using Prism.Mvvm;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace LearningDataStorage
{
    public class MenuItem : INotifyPropertyChanged
    {
        public MenuItem(string name, BindableBase viewModel)
        {
            Name = name;
            ViewModel = viewModel;
        }

        public string Name { get; set; }

        public BindableBase ViewModel { get; set; }

        public ScrollBarVisibility HorizontalScrollBarVisibilityRequirement { get; set; }

        public ScrollBarVisibility VerticalScrollBarVisibilityRequirement { get; set; }

        public Thickness MarginRequirement { get; set; } = new Thickness(16);

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
