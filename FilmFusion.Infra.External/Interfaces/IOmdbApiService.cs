namespace FilmFusion.Infra.External.Interfaces
{
    public interface IOmdbApiService
    {
        Task<OMDbApiNet.Model.Item?> GetItemById(string imdbId);
        Task<OMDbApiNet.Model.Item?> GetItemByTitleAndYear(string title, int year);
    }
}
