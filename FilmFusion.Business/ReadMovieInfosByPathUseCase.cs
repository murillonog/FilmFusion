using FilmFusion.Business.Extensions;
using FilmFusion.Domain.Entities;
using FilmFusion.Domain.Repositories;
using FilmFusion.Domain.UseCases;
using Microsoft.Extensions.Logging;

namespace FilmFusion.Business
{
    public class ReadMovieInfosByPathUseCase : IReadMovieInfosByPathUseCase
    {
        private readonly ILogger<ReadMovieInfosByPathUseCase> _logger;
        private readonly IRepositoryBase<Entertainment> _entertaimentRepository;

        public ReadMovieInfosByPathUseCase(ILogger<ReadMovieInfosByPathUseCase> logger, 
            IRepositoryBase<Entertainment> entertaimentRepository)
        {
            _logger = logger;
            _entertaimentRepository = entertaimentRepository;
        }

        public async Task<IEnumerable<MovieDirectory>> GetMoviesInfoByPathNotInDb(string path)
        {
            var movies = new List<MovieDirectory>();

            _logger.LogInformation($"{DateTime.Now} | Get Movies From Database: BEGIN");

            var moviesDb = await _entertaimentRepository.GetAllAsync();
            var listIds = moviesDb.Select(db => db.ImdbId);

            _logger.LogInformation($"{DateTime.Now} | Get Movies From Database: BEGIN");

            _logger.LogInformation($"{DateTime.Now} | Get Movies By Path: BEGIN");

            foreach (string genre in Directory.GetDirectories(path))
                movies.AddRange(Directory.GetDirectories(genre).Select(m => MovieDirectoryExtensions.FromDirectory(m)));

            _logger.LogInformation($"{DateTime.Now} | Get Movies By Path: END");

            return movies.Where(m => !string.IsNullOrEmpty(m.DetailsPath) && !listIds.Contains(m.ImdbId)).ToList();
        }

        public async Task<IEnumerable<MovieDirectory>> GetMoviesWithoutInfoByPath(string path)
        {
            var movies = new List<MovieDirectory>();

            _logger.LogInformation($"{DateTime.Now} | Get Movies By Path: BEGIN");

            foreach (string genre in Directory.GetDirectories(path))
                movies.AddRange(Directory.GetDirectories(genre).Select(m => MovieDirectoryExtensions.FromDirectory(m)));

            _logger.LogInformation($"{DateTime.Now} | Get Movies By Path: END");

            return movies.Where(m => string.IsNullOrEmpty(m.DetailsPath)).ToList();
        }
    }
}
