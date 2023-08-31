namespace FilmFusion.Infra.External.Interfaces
{
    public interface IImdbApiService
    {
        Task<IMDbApiLib.Models.TitleData?> GetTitleDataById(string imdbId);
    }
}
