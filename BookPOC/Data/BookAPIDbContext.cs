using BookAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Data
{
    public class BookAPIDbContext : DbContext
    {
        public BookAPIDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<BookEntity> Books { get; set; }
    }
}
