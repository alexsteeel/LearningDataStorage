using LearningDataStorage.Core.Models;
using LearningDataStorage.Core.Services;

namespace LearningDataStorage
{
    public class ServicesContainer : IServicesContainer
    {
        public IService<Book> BookService { get; }

        public IService<Country> CountryService { get; }
        public IService<City> CityService { get; }

        public ServicesContainer(IService<Book> bookService,
                                 IService<Country> countryService,
                                 IService<City> cityService)
        {
            BookService = bookService;

            CountryService = countryService;
            CityService = cityService;
        }
    }
}
