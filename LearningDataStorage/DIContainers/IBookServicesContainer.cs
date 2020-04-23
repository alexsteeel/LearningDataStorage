using LearningDataStorage.Core.Models;
using LearningDataStorage.Core.Services;

namespace LearningDataStorage
{
    public interface IBookServicesContainer
    {
        IService<Book> BookService { get; }
        IService<PublishingHouse> PublishingHouseService { get; }
    }
}