﻿using LearningDataStorage.Core.Models;
using LearningDataStorage.Core.Services;

namespace LearningDataStorage
{
    public interface IServicesContainer
    {
        IService<Book> BookService { get; }
        IService<City> CityService { get; }
        IService<Country> CountryService { get; }
    }
}