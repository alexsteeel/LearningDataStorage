using LearningDataStorage.Core.Models;
using LearningDataStorage.Core.Services;

namespace LearningDataStorage
{
    public class CommonServicesContainer : ICommonServicesContainer
    {
        public IService<Country> CountryService { get; }
        public IService<City> CityService { get; }
        public IService<Language> LanguageService { get; }

        public CommonServicesContainer(IService<Country> countryService,
                                       IService<City> cityService,
                                       IService<Language> languageService)
        {
            CountryService = countryService;
            CityService = cityService;
            LanguageService = languageService;
        }
    }
}
