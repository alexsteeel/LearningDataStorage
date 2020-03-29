namespace LearningDataStorage
{
    /// <summary>
    /// Цитата.
    /// </summary>
    public interface IQuote
    {
        int Id { get; set; }

        /// <summary>
        /// Id цитируемого объекта.
        /// </summary>
        int QuotedObjectId { get; set; }

        /// <summary>
        /// Цитируемый объект.
        /// </summary>
        IHasQuotes<IQuote> QuotedObject { get; set; }

        /// <summary>
        /// Текст цитаты.
        /// </summary>
        string Text { get; set; }
    }
}