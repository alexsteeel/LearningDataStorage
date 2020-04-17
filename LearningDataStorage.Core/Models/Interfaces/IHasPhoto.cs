using System.Collections.Generic;

namespace LearningDataStorage.Core.Models
{
    public interface IHasPhoto<IPhoto>
    {
        ICollection<IPhoto> Photo { get; set; }
    }
}
