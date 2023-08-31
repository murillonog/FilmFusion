using FilmFusion.Api.Controllers;
using FilmFusion.Application.Dtos.Request;
using FilmFusion.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FilmFusion.Tests.Controllers
{
    public class DirectoriesControllerTests
    {
        private readonly Mock<ILogger<DirectoriesController>> _logger;
        private readonly Mock<IDirectoryService> _directoryService;
        private readonly DirectoriesController _controller;

        public DirectoriesControllerTests()
        {
            _logger = new Mock<ILogger<DirectoriesController>>();
            _directoryService = new Mock<IDirectoryService>();
            _controller = new DirectoriesController(_logger.Object, _directoryService.Object)
            {
                ControllerContext = new ControllerContext() { HttpContext = new DefaultHttpContext() }
            };
        }

        [Fact]
        public async Task Update_WhenCalled_ReturnsOkResult()
        {
            // Arrange
            var moviePathRequest = new MoviePathRequest("C://Test");
            _directoryService.Setup(service => service.UpdatePath(It.IsAny<MoviePathRequest>()));

            // Act
            var result = await _controller.Update(moviePathRequest);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Update_WhenCalled_ReturnsMessage()
        {
            // Arrange
            var moviePathRequest = new MoviePathRequest("C://Test");
            _directoryService.Setup(service => service.UpdatePath(It.IsAny<MoviePathRequest>())).ReturnsAsync("Success");

            // Act
            var result = await _controller.Update(moviePathRequest) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.IsType<string>(result.Value);
        }
    }
}
