using FilmFusion.Infra.External.Interfaces;
using Microsoft.Extensions.Logging;
using OMDbApiNet;
using OMDbApiNet.Model;

namespace FilmFusion.Infra.External.Services
{
    public class OmdbApiService : IOmdbApiService
    {
        private readonly ILogger<OmdbApiService> _logger;
        private readonly AsyncOmdbClient _omdbClient;

        public OmdbApiService(ILogger<OmdbApiService> logger)
        {
            _logger = logger;
            _omdbClient = new AsyncOmdbClient("18a8e2fa", true);
        }

        public async Task<Item?> GetItemById(string imdbId)
        {
            try
            {
                _logger.LogInformation($"{DateTime.Now} | Try Get Omdb Informations By ImdbId : BEGIN");
                var item = await _omdbClient.GetItemByIdAsync(imdbId);
                _logger.LogInformation($"{DateTime.Now} | Try Get Omdb Informations By ImdbId : END");
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }

        public async Task<Item?> GetItemByTitleAndYear(string title, int year)
        {
            try
            {
                _logger.LogInformation($"{DateTime.Now} | Try Get Omdb Informations By title and year : BEGIN");
                var item = await _omdbClient.GetItemByTitleAsync(title, year, true);
                _logger.LogInformation($"{DateTime.Now} | Try Get Omdb Informations By title and year : END");
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex);
                return null;
            }
        }
    }
}
