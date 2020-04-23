using LearningDataStorage.Core.Models;
using System;
using System.Threading.Tasks;

namespace LearningDataStorage.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IBookRepository Books { get; }

        IRepository<PublishingHouse> PublishingHouses { get; }


        IRepository<City> Cities { get; }

        IRepository<Country> Countries { get; }

        IRepository<Language> Languages { get; }

        Task<int> CommitAsync();
    }
}
