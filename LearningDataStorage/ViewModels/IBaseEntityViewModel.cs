using System;
using System.ComponentModel;

namespace LearningDataStorage
{
    public interface IBaseEntityViewModel : INotifyPropertyChanged, IDataErrorInfo, ICloneable
    {
        event EventHandler OnErrorChanged;
    }
}
