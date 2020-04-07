using System;

namespace LearningDataStorage
{
    public interface IDialog
    {
        event EventHandler OnAccepted;

        event EventHandler OnCanceled;
    }
}
