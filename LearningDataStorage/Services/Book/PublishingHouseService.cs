using LearningDataStorage.Core.Models;
using LearningDataStorage.Core.Repositories;
using LearningDataStorage.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningDataStorage.Services
{
    public class PublishingHouseService : IService<PublishingHouse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public PublishingHouseService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PublishingHouse>> GetAll()
        {
            return await _unitOfWork.PublishingHouses.GetAllAsync();
        }

        public async Task<PublishingHouse> GetById(int id)
        {
            return await _unitOfWork.PublishingHouses.GetByIdAsync(id);
        }

        public async Task<PublishingHouse> Create(PublishingHouse newPublishingHouse)
        {
            await _unitOfWork.PublishingHouses.AddAsync(newPublishingHouse);
            await _unitOfWork.CommitAsync();
            return newPublishingHouse;
        }

        public async Task Delete(PublishingHouse publishingHouse)
        {
            _unitOfWork.PublishingHouses.Remove(publishingHouse);
            await _unitOfWork.CommitAsync();
        }

        public async Task Update(PublishingHouse publishingHouseToBeUpdated, PublishingHouse publishingHouse)
        {
            publishingHouseToBeUpdated.Title = publishingHouse.Title;
            await _unitOfWork.CommitAsync();
        }
    }
}