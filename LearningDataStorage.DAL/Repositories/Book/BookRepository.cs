using LearningDataStorage.Core.Models;
using LearningDataStorage.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningDataStorage.DAL.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(ApplicationContext context)
            : base(context)
        { }

        public async Task<IEnumerable<Book>> GetAllWithContainDataAsync()
        {
            return await ApplicationContext.Books
                            .Include(book => book.BookCover)
                                .ThenInclude(cover => cover.File)
                            .Include(book => book.PublishingHouse)
                            .Include(book => book.City)
                            .Include(book => book.Language)
                            .Include(book => book.BookAuthorLinks)
                                .ThenInclude(bal => bal.Author)
                            .Include(book => book.Ratings)
                                .ThenInclude(rating => rating.Site)
                        .ToListAsync();
        }

        private ApplicationContext ApplicationContext
        {
            get { return Context as ApplicationContext; }
        }
    }
}
