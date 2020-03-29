using System.Collections.Generic;

namespace LearningDataStorage
{
    /// <summary>
    /// Объект, у которого есть фотографии.
    /// </summary>
    public interface IHasPhoto<IPhoto>
    {
        public int Id { get; set; }

        /// <summary>
        /// Фотографии.
        /// </summary>
        ICollection<IPhoto> Photo { get; set; }
    }
}
