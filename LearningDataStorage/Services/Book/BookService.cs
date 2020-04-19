using LearningDataStorage.Core.Models;
using LearningDataStorage.Core.Repositories;
using LearningDataStorage.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LearningDataStorage.Services
{
    public class BookService : IService<Book>
    {
        private readonly IUnitOfWork _unitOfWork;
        public BookService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            return await _unitOfWork.Books
                .GetAllWithContainDataAsync();
        }

        public async Task<Book> GetById(int id)
        {
            return await _unitOfWork.Books.GetByIdAsync(id);
        }

        public async Task<Book> Create(Book newBook)
        {
            await _unitOfWork.Books.AddAsync(newBook);
            await _unitOfWork.CommitAsync();
            return newBook;
        }

        public async Task Delete(Book book)
        {
            _unitOfWork.Books.Remove(book);
            await _unitOfWork.CommitAsync();
        }

        public async Task Update(Book bookToBeUpdated, Book book)
        {
            bookToBeUpdated.Title = book.Title;
            await _unitOfWork.CommitAsync();
        }
    }
}
