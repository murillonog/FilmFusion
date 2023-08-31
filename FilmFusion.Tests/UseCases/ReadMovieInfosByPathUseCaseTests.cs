using FilmFusion.Business;
using FilmFusion.Domain.Entities;
using FilmFusion.Tests.UseCases.Builder;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FilmFusion.Tests.UseCases
{
    public class ReadMovieInfosByPathUseCaseTests
    {
        private readonly Mock<ILogger<ReadMovieInfosByPathUseCase>> _logger;
        private readonly ReadMovieInfosByPathUseCase _useCase;
        public ReadMovieInfosByPathUseCaseTests()
        {
            _logger = new Mock<ILogger<ReadMovieInfosByPathUseCase>>();
            _useCase = new ReadMovieInfosByPathUseCase(_logger.Object);
        }

        [Fact]
        public async Task GetMoviesWithoutInfoByPath_ValidPath_ReturnsMoviesWithoutInfo()
        {
            // Arrange
            var pathBuilder = new PathBuilder();

            // Act
            var result = await _useCase.GetMoviesWithoutInfoByPath(pathBuilder.PathName);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<MovieDirectory>>(result);
        }
    }
}
