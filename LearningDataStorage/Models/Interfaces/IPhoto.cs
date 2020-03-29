using System;

namespace LearningDataStorage
{
    /// <summary>
    /// Фотография.
    /// </summary>
    public interface IPhoto
    {
        Guid StreamId { get; set; }

        /// <summary>
        /// Id объекта с фотографиями.
        /// </summary>
        int ObjectWithPhotoId { get; set; }

        /// <summary>
        /// Объект с фотографиями.
        /// </summary>
        IHasPhoto<IPhoto> ObjectWithPhoto { get; set; }

    }
}