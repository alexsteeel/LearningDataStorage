using LearningDataStorage.Core.Models;
using LearningDataStorage.Core.Repositories;
using LearningDataStorage.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningDataStorage.Services
{
    public class LanguageService : IService<Language>
    {
        private readonly IUnitOfWork _unitOfWork;
        public LanguageService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Language>> GetAll()
        {
            return await _unitOfWork.Languages.GetAllAsync();
        }

        public async Task<Language> GetById(int id)
        {
            return await _unitOfWork.Languages.GetByIdAsync(id);
        }

        public async Task<Language> Create(Language newLanguage)
        {
            await _unitOfWork.Languages.AddAsync(newLanguage);
            await _unitOfWork.CommitAsync();
            return newLanguage;
        }

        public async Task Delete(Language language)
        {
            _unitOfWork.Languages.Remove(language);
            await _unitOfWork.CommitAsync();
        }

        public async Task Update(Language languageToBeUpdated, Language language)
        {
            languageToBeUpdated.Name = language.Name;
            languageToBeUpdated.ISO639Code = language.ISO639Code;
            await _unitOfWork.CommitAsync();
        }
    }
}
