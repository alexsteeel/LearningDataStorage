using System;

namespace LearningDataStorage
{
    public interface IDialogPage
    {
        event EventHandler OnAccepted;

        event EventHandler OnCanceled;
    }
}
