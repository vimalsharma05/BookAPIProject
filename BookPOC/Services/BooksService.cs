using BookAPI.Data;
using BookAPI.Models;

namespace BookAPI.Services
{
    public class BooksService : IBooksService
    {
        private readonly IDataRepository _repository;
        public BooksService(IDataRepository repository)
        {
            _repository = repository;
        }
        public async Task<BookEntity> AddBook(Book bookData)
        {
            try
            {
                BookEntity book = new BookEntity
                {
                    Id = Guid.NewGuid(),
                    Name = bookData.Name,
                    AutherName = bookData.AutherName
                };
                await _repository.AddBook(book);
                return book;
            }
            catch
            {
                throw;
            }
           
        }

        public async Task<BookEntity?> GetBookById(Guid id)
        {
            try
            {
                return await _repository.GetBookById(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<BookEntity>> GetBooks()
        {
            try
            {
                return await _repository.GetBooks();
            }
            catch
            {
                throw;
            }
        }
    }
}
