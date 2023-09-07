using AutoMapper;
using FilmFusion.Application.Dtos.Models;
using FilmFusion.Application.Dtos.Request;
using FilmFusion.Application.Interfaces;
using FilmFusion.Domain.Entities;
using FilmFusion.Domain.UseCases;
using Microsoft.Extensions.Logging;

namespace FilmFusion.Application.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<DatabaseService> _logger;
        private readonly IReadMovieInfosByPathUseCase _readMovieInfosByPathUseCase;
        private readonly IInsertMovieInformationUseCase _insertMovieInformationUseCase;
        public int count = 0;

        public DatabaseService(IMapper mapper, ILogger<DatabaseService> logger, 
            IReadMovieInfosByPathUseCase readMovieInfosByPathUseCase, 
            IInsertMovieInformationUseCase insertMovieInformationUseCase)
        {
            _mapper = mapper;
            _logger = logger;
            _readMovieInfosByPathUseCase = readMovieInfosByPathUseCase;
            _insertMovieInformationUseCase = insertMovieInformationUseCase;
        }

        public async Task<string> LoadMoviesSqlServer(MoviePathRequest moviePathRequest)
        {
            _logger.LogInformation($"{DateTime.Now} | Load all initial movies from path: BEGIN");

            if (Directory.Exists(moviePathRequest.Path))
            {
                var movies = await _readMovieInfosByPathUseCase.GetMoviesInfoByPathNotInDb(moviePathRequest.Path);
                foreach (var movie in movies)
                {
                    var entertainmentDto = new EntertainmentDto(_mapper.Map<MovieDirectoryDto>(movie));
                    if (await _insertMovieInformationUseCase.InsertMovieSqlServer(_mapper.Map<Entertainment>(entertainmentDto)))
                        count++;
                }
            }

            _logger.LogInformation($"{DateTime.Now} | Load all initial movies from path: END");
            return $"Total registered: {count} inserted in SQL SERVER";
        }
    }
}
