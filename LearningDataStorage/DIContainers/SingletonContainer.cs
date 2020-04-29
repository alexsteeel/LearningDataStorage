using AutoMapper;
using log4net;
using System.Windows;

namespace LearningDataStorage
{
    public class SingletonContainer : ISingletonContainer
    {
        public ILog Log { get; }
        public ResourceDictionary Localization { get; }
        public IDialog Dialog { get; }
        public IMapper Mapper { get; }

        public SingletonContainer(ILog log, ResourceDictionary localization, IDialog dialog, IMapper mapper)
        {
            Log = log;
            Localization = localization;
            Dialog = dialog;
            Mapper = mapper;
        }
    }
}
