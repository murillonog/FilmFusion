using FilmFusion.Infra.External.Services;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace FilmFusion.Tests.Externals
{
    public class ImdbApiServiceTests
    {
        private readonly Mock<ILogger<ImdbApiService>> _logger;
        private readonly ImdbApiService _service;
        public ImdbApiServiceTests()
        {
            _logger = new Mock<ILogger<ImdbApiService>>();
            _service = new ImdbApiService(_logger.Object);
        }

        [Fact]
        public async Task GetTitleDataById_ValidImdbId_ReturnsTitleData()
        {
            //// Arrange
            //var apiLibMock = new Mock<ApiLib>("fake_api_key");
            //apiLibMock.Setup(api => api.TitleAsync(It.IsAny<string>(), Language.pt_BR, true, true, true, true, true, true, true))
            //          .ReturnsAsync(new TitleData ());

            //// Set the ApiLib client in the ImdbApiService using reflection (private field)
            //var fieldInfo = typeof(ImdbApiService).GetField("_imdbClient", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            //fieldInfo.SetValue(_service, apiLibMock.Object);

            //// Act
            //var result = await _service.GetTitleDataById("tt1234567");

            //// Assert
            //Assert.NotNull(result);
            //Assert.Equal("Test Movie", result.Title);
            //Assert.Equal("2023", result.Year);
        }
    }
}
