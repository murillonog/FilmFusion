using FilmFusion.Domain.Entities;

namespace FilmFusion.Domain.UseCases
{
    public interface IInsertMovieInformationUseCase
    {
        Task<bool> InsertMovieSqlServer(Entertainment entertainment);
    }
}
