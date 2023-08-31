using AutoMapper;
using FilmFusion.Application.Dtos.Request;
using FilmFusion.Application.Services;
using FilmFusion.Domain.Entities;
using FilmFusion.Domain.File;
using FilmFusion.Domain.UseCases;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FilmFusion.Tests.Services
{
    public class DirectoryServiceTests
    {
        private readonly Mock<IMapper> _mapper;
        private readonly Mock<ILogger<DirectoryService>> _logger;
        private readonly Mock<IReadMovieInfosByPathUseCase> _readMovieInfosByPathUseCase;
        private readonly Mock<IGetMovieInfoByDirectoryUseCase> _getMovieInfoByDirectoryUseCase;
        private readonly DirectoryService _service;

        public DirectoryServiceTests()
        {
            _mapper = new Mock<IMapper>();
            _logger = new Mock<ILogger<DirectoryService>>();
            _readMovieInfosByPathUseCase = new Mock<IReadMovieInfosByPathUseCase>();
            _getMovieInfoByDirectoryUseCase = new Mock<IGetMovieInfoByDirectoryUseCase>();

            _service = new DirectoryService(_mapper.Object, _logger.Object, _readMovieInfosByPathUseCase.Object, _getMovieInfoByDirectoryUseCase.Object);
        }

        [Fact]
        public async Task UpdatePath_ValidPath_ReturnsSuccessMessage()
        {
            // Arrange
            var moviePathRequest = new MoviePathRequest("E:\\Filmes");

            _readMovieInfosByPathUseCase.Setup(useCase => useCase.GetMoviesWithoutInfoByPath(moviePathRequest.Path))
                .ReturnsAsync(new List<MovieDirectory>());

            _getMovieInfoByDirectoryUseCase.Setup(useCase => useCase.GetInformationsByApis(It.IsAny<MovieDirectory>()))
                .ReturnsAsync(new Movie());

            // Act
            var result = await _service.UpdatePath(moviePathRequest);

            // Assert
            Assert.Contains("Total register", result);
            Assert.Contains("Success:0", result);
        }

        [Fact]
        public async Task UpdatePath_InvalidPath_ThrowsException()
        {
            // Arrange
            var moviePathRequest = new MoviePathRequest("invalid/path");

            _readMovieInfosByPathUseCase.Setup(useCase => useCase.GetMoviesWithoutInfoByPath(moviePathRequest.Path))
                .ThrowsAsync(new Exception("Directory not exists."));

            // Assert
            await Assert.ThrowsAsync<Exception>(() => _service.UpdatePath(moviePathRequest));
        }
    }
}
