namespace LearningDataStorage
{
    /// <summary>
    /// Цитата.
    /// </summary>
    public interface IQuote
    {
        int Id { get; set; }

        /// <summary>
        /// Текст цитаты.
        /// </summary>
        string Text { get; set; }
    }
}