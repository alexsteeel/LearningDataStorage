using LearningDataStorage.Core.Models;
using LearningDataStorage.Core.Repositories;
using LearningDataStorage.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningDataStorage.Services
{
    public class CountryService : IService<Country>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CountryService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Country>> GetAll()
        {
            return await _unitOfWork.Countries.GetAllAsync();
        }

        public async Task<Country> Create(Country newCountry)
        {
            await _unitOfWork.Countries.AddAsync(newCountry);
            await _unitOfWork.CommitAsync();
            return newCountry;
        }

        public async Task Delete(Country country)
        {
            _unitOfWork.Countries.Remove(country);
            await _unitOfWork.CommitAsync();
        }

        public async Task Update(Country countryToBeUpdated, Country country)
        {
            countryToBeUpdated.Name = country.Name;
            await _unitOfWork.CommitAsync();
        }
    }
}
