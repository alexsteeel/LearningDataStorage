using LearningDataStorage.Core.Models;
using System;
using System.Threading.Tasks;

namespace LearningDataStorage.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository Books { get; }

        IRepository<City> Cities { get; set; }

        IRepository<Country> Countries { get; set; }

        Task<int> CommitAsync();
    }
}
