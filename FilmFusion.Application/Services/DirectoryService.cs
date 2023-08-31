using AutoMapper;
using FilmFusion.Application.Dtos.Request;
using FilmFusion.Application.Interfaces;
using FilmFusion.Application.Utils;
using FilmFusion.Domain.Entities;
using FilmFusion.Domain.File;
using FilmFusion.Domain.UseCases;
using Microsoft.Extensions.Logging;

namespace FilmFusion.Application.Services
{
    public class DirectoryService : IDirectoryService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<DirectoryService> _logger;
        private readonly IReadMovieInfosByPathUseCase _readMovieInfosByPathUseCase;
        private readonly IGetMovieInfoByDirectoryUseCase _getMovieInfoByDirectoryUseCase;

        public DirectoryService(IMapper mapper,
            ILogger<DirectoryService> logger,
            IReadMovieInfosByPathUseCase readMovieInfosByPathUseCase,
            IGetMovieInfoByDirectoryUseCase getMovieInfoByDirectoryUseCase)
        {
            _mapper = mapper;
            _logger = logger;
            _readMovieInfosByPathUseCase = readMovieInfosByPathUseCase;
            _getMovieInfoByDirectoryUseCase = getMovieInfoByDirectoryUseCase;
        }

        public async Task<string> UpdatePath(MoviePathRequest moviePathRequest)
        {
            var success = 0;

            if (!Directory.Exists(moviePathRequest.Path))
                throw new Exception("Directory not exists.");

            _logger.LogInformation($"{DateTime.Now} | Get Movies Without Informations By Path: BEGIN");

            var moviePaths = await _readMovieInfosByPathUseCase.GetMoviesWithoutInfoByPath(moviePathRequest.Path);

            _logger.LogInformation($"{DateTime.Now} | Get Movies Without Informations By Path: END");

            foreach (var moviePath in moviePaths)
            {
                _logger.LogInformation($"{DateTime.Now} | Get Movies Informations By External APIs: BEGIN");

                var details = await _getMovieInfoByDirectoryUseCase.GetInformationsByApis(_mapper.Map<MovieDirectory>(moviePath));

                _logger.LogInformation($"{DateTime.Now} | Get Movies Informations By External APIs: END");

                if (ValidateDetails(details))
                {
                    _logger.LogInformation($"{DateTime.Now} | Write Movie Informations: BEGIN");

                    new WriterText($"{moviePath.RootPath}\\_details.json").WriterMovieDetails(details);

                    _logger.LogInformation($"{DateTime.Now} | Write Movie Informations: END");
                    success++;
                }
            }

            return $"Total register: {moviePaths.Count()}. Success:{success}";
        }

        private static bool ValidateDetails(Movie details)
        {
            return (details.ImdbInfo != null && details.OmdbInfo != null) &&
                    (!string.IsNullOrEmpty(details.ImdbInfo.Title) && !string.IsNullOrEmpty(details.OmdbInfo.Title));
        }
    }
}
