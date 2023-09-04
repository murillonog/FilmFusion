using FilmFusion.Business.Extensions;
using FilmFusion.Domain.Entities;
using FilmFusion.Domain.UseCases;
using Microsoft.Extensions.Logging;

namespace FilmFusion.Business
{
    public class ReadMovieInfosByPathUseCase : IReadMovieInfosByPathUseCase
    {
        private readonly ILogger<ReadMovieInfosByPathUseCase> _logger;

        public ReadMovieInfosByPathUseCase(ILogger<ReadMovieInfosByPathUseCase> logger)
        {
            _logger = logger;
        }

        public async Task<IEnumerable<MovieDirectory>> GetMoviesInfoByPath(string path)
        {
            var movies = new List<MovieDirectory>();

            _logger.LogInformation($"{DateTime.Now} | Get Movies By Path: BEGIN");

            foreach (string genre in Directory.GetDirectories(path))
                movies.AddRange(Directory.GetDirectories(genre).Select(m => MovieDirectoryExtensions.FromDirectory(m)));

            _logger.LogInformation($"{DateTime.Now} | Get Movies By Path: END");

            return movies.Where(m => !string.IsNullOrEmpty(m.DetailsPath)).ToList();
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
