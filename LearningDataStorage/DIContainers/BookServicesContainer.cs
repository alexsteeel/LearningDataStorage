using LearningDataStorage.Core.Models;
using LearningDataStorage.Core.Services;

namespace LearningDataStorage
{
    public class BookServicesContainer : IBookServicesContainer
    {
        public IService<Book> BookService { get; }
        public IService<PublishingHouse> PublishingHouseService { get; }

        public BookServicesContainer(IService<Book> bookService,
                                     IService<PublishingHouse> publishingHouseService)
        {
            BookService = bookService;
            PublishingHouseService = publishingHouseService;
        }
    }
}
