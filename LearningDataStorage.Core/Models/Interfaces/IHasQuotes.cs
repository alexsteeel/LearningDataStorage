using System.Collections.Generic;

namespace LearningDataStorage.Core.Models
{
    public interface IHasQuotes<IQuote>
    {
        ICollection<IQuote> Quotes { get; set; }
    }
}
