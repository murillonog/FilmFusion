using FilmFusion.Domain.Entities;

namespace FilmFusion.Domain.UseCases
{
    public interface IReadMovieInfosByPathUseCase
    {
        Task<IEnumerable<MovieDirectory>> GetMoviesWithoutInfoByPath(string path);
        Task<IEnumerable<MovieDirectory>> GetMoviesInfoByPathNotInDb(string path);
    }
}
