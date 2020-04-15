using log4net;
using Prism.Mvvm;
using System.Windows;

namespace LearningDataStorage
{
    public abstract class BaseViewModel : BindableBase
    {
        protected readonly ILog _log;
        protected readonly ResourceDictionary _localization;
        protected readonly IDialog _dialog;

        protected BaseViewModel(ILog log, ResourceDictionary localization, IDialog dialog)
        {
            _log = log;
            _localization = localization;
            _dialog = dialog;
        }
    }
}
