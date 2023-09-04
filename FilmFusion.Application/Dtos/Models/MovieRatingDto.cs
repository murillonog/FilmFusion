using FilmFusion.Application.Dtos.File;

namespace FilmFusion.Application.Dtos.Models
{
    public class MovieRatingDto: BaseDto
    {       
        public string? TheMovieDb { get; set; }
        public string? RottenTomatoes { get; set; }
        public string? FilmAffinity { get; set; }
        public string? Metascore { get; set; }

        public Guid EntertainmentId { get; set; }

        public MovieRatingDto(Guid id, MovieDto movieDto)
        {
            this.Id = Guid.NewGuid();
            this.TheMovieDb = movieDto.ImdbInfo?.Ratings?.TheMovieDb;
            this.RottenTomatoes = movieDto.ImdbInfo?.Ratings?.RottenTomatoes;
            this.FilmAffinity = movieDto.ImdbInfo?.Ratings?.FilmAffinity;
            this.Metascore = movieDto.ImdbInfo?.Ratings?.Metacritic;
            this.EntertainmentId = id;
        }
    }
}
