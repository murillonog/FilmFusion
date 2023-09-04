using FilmFusion.Application.Dtos.Request;

namespace FilmFusion.Application.Interfaces
{
    public interface IDatabaseService
    {
        Task<string> LoadMoviesSqlServer(MoviePathRequest moviePathRequest);
    }
}
