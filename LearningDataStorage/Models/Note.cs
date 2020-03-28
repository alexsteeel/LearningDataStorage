using System;

namespace LearningDataStorage
{
    /// <summary>
    /// Заметка.
    /// </summary>
    public class Note
    {
        public int Id { get; set; }

        public int NoteId { get; set; }

        /// <summary>
        /// Дата создания/изменения.
        /// </summary>
        public DateTime ChangeDate { get; set; }

        /// <summary>
        /// Текст заметки.
        /// </summary>
        public string Text { get; set; }
    }
}