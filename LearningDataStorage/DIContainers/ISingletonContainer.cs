using log4net;
using System.Windows;

namespace LearningDataStorage
{
    public interface ISingletonContainer
    {
        IDialog Dialog { get; }
        ResourceDictionary Localization { get; }
        ILog Log { get; }
    }
}