using BookAPI.Models;

namespace BookAPI.Services
{
    public interface IBooksService
    {
        Task<BookEntity> AddBook(Book book);
        Task<List<BookEntity>> GetBooks();
        Task<BookEntity?> GetBookById(Guid id);
    }
}
