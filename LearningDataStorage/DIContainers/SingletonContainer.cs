using log4net;
using System.Windows;

namespace LearningDataStorage
{
    public class SingletonContainer : ISingletonContainer
    {
        public ILog Log { get; }
        public ResourceDictionary Localization { get; }
        public IDialog Dialog { get; }

        public SingletonContainer(ILog log, ResourceDictionary localization, IDialog dialog)
        {
            Log = log;
            Localization = localization;
            Dialog = dialog;
        }
    }
}
