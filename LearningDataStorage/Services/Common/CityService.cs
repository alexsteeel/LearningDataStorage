using LearningDataStorage.Core.Models;
using LearningDataStorage.Core.Repositories;
using LearningDataStorage.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningDataStorage.Services
{
    public class CityService : IService<City>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CityService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<City>> GetAll()
        {
            return await _unitOfWork.Cities.GetAllAsync();
        }

        public async Task<City> GetById(int id)
        {
            return await _unitOfWork.Cities.GetByIdAsync(id);
        }

        public async Task<City> Create(City newCity)
        {
            await _unitOfWork.Cities.AddAsync(newCity);
            await _unitOfWork.CommitAsync();
            return newCity;
        }

        public async Task Delete(City city)
        {
            _unitOfWork.Cities.Remove(city);
            await _unitOfWork.CommitAsync();
        }

        public async Task Update(City cityToBeUpdated, City city)
        {
            cityToBeUpdated.Name = city.Name;
            await _unitOfWork.CommitAsync();
        }
    }
}
