using FilmFusion.Infra.External.Interfaces;
using IMDbApiLib;
using IMDbApiLib.Models;
using Microsoft.Extensions.Logging;

namespace FilmFusion.Infra.External.Services
{
    public class ImdbApiService : IImdbApiService
    {
        private readonly ILogger<ImdbApiService> _logger;
        private readonly ApiLib _imdbClient;

        public ImdbApiService(ILogger<ImdbApiService> logger)
        {
            _logger = logger;
            _imdbClient = new ApiLib("k_8w0eqh52");
        }

        public async Task<TitleData?> GetTitleDataById(string imdbId)
        {
            try
            {
                _logger.LogInformation($"{DateTime.Now} | Try Get Imdb Information By ImdbId : BEGIN");
                var data = await _imdbClient.TitleAsync(imdbId, Language.pt_BR, true, true, true, true, true, true, true);
                _logger.LogInformation($"{DateTime.Now} | Try Get Imdb Information By ImdbId : END");

                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }
    }
}
