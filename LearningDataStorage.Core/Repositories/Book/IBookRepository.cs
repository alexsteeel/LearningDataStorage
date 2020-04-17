using LearningDataStorage.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningDataStorage.Core.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<IEnumerable<Book>> GetAllWithContainDataAsync();

        Task<Book> GetWithContainDataByIdAsync(int id);

    }
}
