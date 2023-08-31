using FilmFusion.Domain.Entities;
using FilmFusion.Domain.File;

namespace FilmFusion.Domain.UseCases
{
    public interface IGetMovieInfoByDirectoryUseCase
    {
        Task<Movie> GetInformationsByApis(MovieDirectory movieDirectory);
    }
}
