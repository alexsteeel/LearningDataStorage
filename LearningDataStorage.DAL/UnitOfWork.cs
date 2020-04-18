using LearningDataStorage.Core.Models;
using LearningDataStorage.Core.Repositories;
using LearningDataStorage.DAL.Repositories;
using System.Threading.Tasks;

namespace LearningDataStorage.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;

        private BookRepository _bookRepository;

        private Repository<City> _cityRepository;

        private Repository<Country> _countryRepository;

        public UnitOfWork(ApplicationContext context)
        {
            this._context = context;
        }

        public IBookRepository Books => _bookRepository ??= new BookRepository(_context);

        public IRepository<City> Cities => _cityRepository ??= new Repository<City>(_context);

        public IRepository<Country> Countries => _countryRepository ??= new Repository<Country>(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
