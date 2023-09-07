using FilmFusion.Api.Controllers;
using FilmFusion.Application.Dtos.Request;
using FilmFusion.Application.Interfaces;
using FilmFusion.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FilmFusion.Tests.Controllers
{
    public class SyncControllerTests
    {
        private readonly Mock<ILogger<SyncController>> _logger;
        private readonly Mock<IDatabaseService> _dataBaseService;
        private readonly SyncController _controller;
        public SyncControllerTests()
        {
            _logger = new Mock<ILogger<SyncController>>();
            _dataBaseService = new Mock<IDatabaseService>();
            _controller = new SyncController(_logger.Object, _dataBaseService.Object)
            {
                ControllerContext = new ControllerContext() { HttpContext = new DefaultHttpContext() }
            };
        }

        [Fact]
        public async Task Update_WhenCalled_ReturnsOkResult()
        {
            // Arrange
            var moviePathRequest = new MoviePathRequest("C://Test");
            _dataBaseService.Setup(service => service.LoadMoviesSqlServer(It.IsAny<MoviePathRequest>()));

            // Act
            var result = await _controller.Sync(moviePathRequest);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Update_WhenCalled_ReturnsMessage()
        {
            // Arrange
            var moviePathRequest = new MoviePathRequest("C://Test");
            _dataBaseService.Setup(service => service.LoadMoviesSqlServer(It.IsAny<MoviePathRequest>())).ReturnsAsync("Success");

            // Act
            var result = await _controller.Sync(moviePathRequest) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<string>(result.Value);
        }
    }
}
