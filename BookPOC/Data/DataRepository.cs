using BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Data
{
    public class DataRepository : IDataRepository
    {
        private readonly BookAPIDbContext _dbContext;

        public DataRepository(BookAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<BookEntity> AddBook(BookEntity book)
        {
            try
            {
                await _dbContext.Books.AddAsync(book);
                await _dbContext.SaveChangesAsync();
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
                var result = await _dbContext.Books.FindAsync(id);
                return result;
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
                var result = await _dbContext.Books.ToListAsync();
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}
