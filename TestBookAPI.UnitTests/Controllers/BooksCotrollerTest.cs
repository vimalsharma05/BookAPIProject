using BookAPI.Controllers;
using BookAPI.Data;
using BookAPI.Models;
using BookAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace TestBookAPI.UnitTests.Controllers
{
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
        public async Task AddBooks_Should_Return200()
        {
            //Arrange 
            Book book = new Book();
            book.Name = "DataStructure";
            book.AutherName = "G.S. Baluja";

            //Act
            var result = await sut.AddBook(book);

            //Assert
            var output = Assert.IsType<OkObjectResult>(result);
            result.Equals(book);
            Assert.Equal(200, output.StatusCode);
        }
        [Fact]
        public async Task GetBooks_Should_Return200()
        {
            //Arrange
            List<BookEntity> bookList = new List<BookEntity> { new BookEntity { Id = Guid.NewGuid(), Name = "testBook", AutherName = "testAuther" } };
            _mockRepository.Setup(x => x.GetBooks()).ReturnsAsync(bookList);

            //Act
            var result = await sut.GetBooks();

            //Assert
            var output = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, output.StatusCode);
        }
        [Fact]
        public async Task GetBooks_ById_Should_Return200()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            BookEntity bookEntity = new BookEntity
            {
                Id = id,
                Name = "testBook",
                AutherName = "testAuther"
            };
            _mockRepository.Setup(x => x.GetBookById(id)).ReturnsAsync(bookEntity);
            
            //Act
            var result = await sut.GetBookById(id);

            //Assert
            var output = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, output.StatusCode);
            Assert.Equal(id, ((BookEntity)((ObjectResult)result).Value).Id);
        }
    }
}