using System;

namespace LearningDataStorage
{
    /// <summary>
    /// Диалог.
    /// </summary>
    public interface IDialog
    {
        /// <summary>
        /// Подтверждение изменений.
        /// </summary>
        event EventHandler IsAccepted;

        /// <summary>
        /// Отмена.
        /// </summary>
        event EventHandler IsCanceled;

    }
}
