using System.Collections.Generic;

namespace LearningDataStorage.DAL
{
    /// <summary>
    /// Объект, у которого есть фотографии.
    /// </summary>
    public interface IHasPhoto<IPhoto>
    {
        /// <summary>
        /// Фотографии.
        /// </summary>
        ICollection<IPhoto> Photo { get; set; }
    }
}
