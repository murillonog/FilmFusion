using FilmFusion.Business;
using FilmFusion.Domain.Entities;
using FilmFusion.Infra.External.Interfaces;
using IMDbApiLib.Models;
using Microsoft.Extensions.Logging;
using Moq;
using OMDbApiNet.Model;
using System.Text.Json;
using Xunit;

namespace FilmFusion.Tests.UseCases
{
    public class GetMovieInfoByDirectoryUseCaseTests
    {
        private readonly Mock<ILogger<GetMovieInfoByDirectoryUseCase>> _logger;
        private readonly Mock<IOmdbApiService> _omdbApiService;
        private readonly Mock<IImdbApiService> _imdbApiService;
        private readonly GetMovieInfoByDirectoryUseCase _useCase;

        public GetMovieInfoByDirectoryUseCaseTests()
        {
            _logger = new Mock<ILogger<GetMovieInfoByDirectoryUseCase>>();
            _omdbApiService = new Mock<IOmdbApiService>();
            _imdbApiService = new Mock<IImdbApiService>();
            _useCase = new GetMovieInfoByDirectoryUseCase(_logger.Object, _omdbApiService.Object, _imdbApiService.Object);
        }

        [Fact]
        public async Task GetInformationsByApis_ValidMovieDirectory_ReturnsMovieInfo()
        {
            // Arrange
            var tempOmdbPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".json");
            var tempImdbPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".json");
            var movieDirectory = new MovieDirectory
            {
                Title = "Test Movie",
                Year = "2023",
                ImdbId = "tt1234567",
                OmdbPath = tempOmdbPath,
                ImdbPath = tempImdbPath
            };

            var omdbInfo = new Item { Title = "Test Movie", Year = "2023" };
            var imdbInfo = new TitleData { Title = "Test Movie", Year = "2023" };

            _omdbApiService.Setup(service => service.GetItemById(movieDirectory.ImdbId))
                .ReturnsAsync(omdbInfo);

            _imdbApiService.Setup(service => service.GetTitleDataById(movieDirectory.ImdbId))
                .ReturnsAsync(imdbInfo);

            File.WriteAllText(tempOmdbPath, JsonSerializer.Serialize(omdbInfo));
            File.WriteAllText(tempImdbPath, JsonSerializer.Serialize(imdbInfo));

            //Act
            var result = await _useCase.GetInformationsByApis(movieDirectory);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Test Movie", result.Title);
            Assert.Equal("2023", result.Year);
            Assert.Equal("tt1234567", result.ImdbId);

            // Cleanup
            File.Delete(tempOmdbPath);
            File.Delete(tempImdbPath);
        }
    }
}
