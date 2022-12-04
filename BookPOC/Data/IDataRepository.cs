using BookAPI.Models;

namespace BookAPI.Data
{
    public interface IDataRepository
    {
        Task<BookEntity> AddBook(BookEntity book);
        Task<List<BookEntity>> GetBooks();
        Task<BookEntity?> GetBookById(Guid id);
    }
}
