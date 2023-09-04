using IMDbApiLib.Models;
using OMDbApiNet.Model;

namespace FilmFusion.Application.Dtos.File
{
    public class MovieDto
    {
        public MovieDto() { }

        public string Title { get; set; }
        public string Year { get; set; }
        public string ImdbId { get; set; }
        public bool IsWatched { get; set; }
        public Item? OmdbInfo { get; set; }
        public TitleData? ImdbInfo { get; set; }
    }
}
