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
        protected readonly ISingletonContainer _mainContainer;

        protected BaseViewModel(ISingletonContainer mainContainer)
        {
            _log = mainContainer.Log;
            _localization = mainContainer.Localization;
            _dialog = mainContainer.Dialog;
            _mainContainer = mainContainer;
        }
    }
}
