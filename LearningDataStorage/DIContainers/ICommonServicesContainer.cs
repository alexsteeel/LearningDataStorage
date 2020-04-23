using LearningDataStorage.Core.Models;
using LearningDataStorage.Core.Services;

namespace LearningDataStorage
{
    public interface ICommonServicesContainer
    {
        IService<City> CityService { get; }
        IService<Country> CountryService { get; }
        IService<Language> LanguageService { get; }
    }
}