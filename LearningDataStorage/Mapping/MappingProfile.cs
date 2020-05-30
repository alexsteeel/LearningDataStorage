using AutoMapper;
using LearningDataStorage.Core.Models;

namespace LearningDataStorage
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Commmon.
            CreateMap<CityViewModel, City>();
            CreateMap<City, CityViewModel>();

            CreateMap<CountryViewModel, Country>();
            CreateMap<Country, CountryViewModel>();

            CreateMap<LanguageViewModel, Language>();
            CreateMap<Language, LanguageViewModel>();
        }
    }
}