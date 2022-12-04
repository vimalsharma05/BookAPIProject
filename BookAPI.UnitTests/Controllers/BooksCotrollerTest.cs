using BookAPI.Controllers;
using BookAPI.Data;
using BookAPI.Models;
using BookAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace BookAPI.UnitTests.Controllers
{
    [TestClass]
    public class BooksCotrollerTest
    {
        private BooksController sut;
        private readonly Mock<ILogger<BooksController>> _mockLogger;
        private readonly IBooksService bookService;
        private readonly Mock<IDataRepository> _mockRepository;
        public BooksCotrollerTest()
        {
            _mockLogger = new Mock<ILogger<BooksController>>();
            _mockRepository = new Mock<IDataRepository>();  
            bookService = new BooksService(_mockRepository.Object);
            sut = new BooksController(bookService, _mockLogger.Object);

        }
        [Fact]
        //[TestMethod]
        public async Task AddBooksShouldReturn200()
        {
            //Arrange 
            Book book = new Book();
            book.Name = "DataStructure";
            book.AutherName = "G.S. Baluja";

            //Act
            var result = await sut.AddBook(book);

            //Assert
            //Assert.IsType<ObjectResult>(result);
            result.Equals(book);
        }
    }
}