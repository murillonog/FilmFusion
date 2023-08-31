using FilmFusion.Domain.Entities;
using FilmFusion.Domain.File;
using FilmFusion.Domain.UseCases;
using FilmFusion.Infra.External.Interfaces;
using IMDbApiLib.Models;
using Microsoft.Extensions.Logging;
using OMDbApiNet.Model;
using System.Text.Json;

namespace FilmFusion.Business
{
    public class GetMovieInfoByDirectoryUseCase : IGetMovieInfoByDirectoryUseCase
    {
        private readonly ILogger<GetMovieInfoByDirectoryUseCase> _logger;
        private readonly IOmdbApiService _omdbApiService;
        private readonly IImdbApiService _imdbApiService;

        public GetMovieInfoByDirectoryUseCase(
            ILogger<GetMovieInfoByDirectoryUseCase> logger, 
            IOmdbApiService omdbApiService, 
            IImdbApiService imdbApiService)
        {
            _logger = logger;
            _omdbApiService = omdbApiService;
            _imdbApiService = imdbApiService;
        }

        public async Task<Movie> GetInformationsByApis(MovieDirectory movieDirectory)
        {
            Item? omdbInfo;
            TitleData? imdbInfo;

            if (string.IsNullOrWhiteSpace(movieDirectory.OmdbPath))
            {
                _logger.LogInformation($"{DateTime.Now} | Get Informations in Omdb API about movie by imdbId: BEGIN");

                omdbInfo = await _omdbApiService.GetItemById(movieDirectory.ImdbId);

                _logger.LogInformation($"{DateTime.Now} | Get Informations in Omdb API about movie by imdbId: END");

                if (omdbInfo == null)
                {
                    _logger.LogInformation($"{DateTime.Now} | Get Informations in Omdb API about movie by Title and Year: BEGIN");

                    omdbInfo = await _omdbApiService.GetItemByTitleAndYear(movieDirectory.Title, Convert.ToInt32(movieDirectory.Year));

                    _logger.LogInformation($"{DateTime.Now} | Get Informations in Omdb API about movie by Title and Year: END");
                }
            }
            else
            {
                _logger.LogInformation($"{DateTime.Now} | Get Informations Omdb file: BEGIN");

                omdbInfo = JsonSerializer.Deserialize<Item>(File.ReadAllText(movieDirectory.OmdbPath));

                _logger.LogInformation($"{DateTime.Now} | Get Informations Omdb file: END");
            }

            if (string.IsNullOrEmpty(movieDirectory.ImdbPath))
            {
                _logger.LogInformation($"{DateTime.Now} | Get Informations in Imdb API about movie by imdbId: BEGIN");

                imdbInfo = await _imdbApiService.GetTitleDataById(movieDirectory.ImdbId);

                _logger.LogInformation($"{DateTime.Now} | Get Informations in Imdb API about movie by imdbId: BEGIN");
            }
            else
            {
                _logger.LogInformation($"{DateTime.Now} | Get Informations Imdb file: BEGIN");

                imdbInfo = JsonSerializer.Deserialize<TitleData>(File.ReadAllText(movieDirectory.ImdbPath),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                _logger.LogInformation($"{DateTime.Now} | Get Informations Imdb file: END");

            }

            return new Movie
            {
                Title = movieDirectory.Title,
                Year = movieDirectory.Year,
                ImdbId = movieDirectory.ImdbId,
                IsWatched = movieDirectory.IsWatched,
                OmdbInfo = omdbInfo,
                ImdbInfo = imdbInfo
            };
        }
    }
}
