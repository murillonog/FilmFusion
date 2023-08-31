using FilmFusion.Application.Dtos.Request;

namespace FilmFusion.Application.Interfaces
{
    public interface IDirectoryService
    {
        Task<string> UpdatePath(MoviePathRequest moviePathRequest);
    }
}
