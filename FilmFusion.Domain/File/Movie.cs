using IMDbApiLib.Models;
using OMDbApiNet.Model;

namespace FilmFusion.Domain.File
{
    public class Movie
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string ImdbId { get; set; }
        public bool IsWatched { get; set; }
        public Item? OmdbInfo { get; set; }
        public TitleData? ImdbInfo { get; set; }
        public Movie() { }
    }
}
