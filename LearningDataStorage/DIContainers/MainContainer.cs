using log4net;
using System.Windows;

namespace LearningDataStorage
{
    public class MainContainer : IMainContainer
    {
        public ILog Log { get; }
        public ResourceDictionary Localization { get; }
        public IDialog Dialog { get; }

        public MainContainer(ILog log, ResourceDictionary localization, IDialog dialog)
        {
            Log = log;
            Localization = localization;
            Dialog = dialog;
        }
    }
}
