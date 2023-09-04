using FilmFusion.Application.Dtos.File;

namespace FilmFusion.Application.Dtos.Models
{
    public class MovieDetailDto:BaseDto
    {       
        public string? Rated { get; set; }
        public string? OriginalTitle { get; set; }
        public string? Genre { get; set; }
        public string? ReleaseDate { get; set; }
        public string? RuntimeMins { get; set; }
        public string? RuntimeStr { get; set; }
        public string? Plot { get; set; }
        public string? PlotLocal { get; set; }
        public string? Directors { get; set; }
        public string? Writer { get; set; }
        public string? Stars { get; set; }
        public string? Companies { get; set; }
        public string? Countries { get; set; }
        public string? Languages { get; set; }
        public string? Tagline { get; set; }
        public string? Awards { get; set; }

        public Guid EntertainmentId { get; set; }

        public MovieDetailDto(Guid id, MovieDto movieDto)
        {
            this.Id = Guid.NewGuid();
            this.Rated = movieDto.OmdbInfo?.Rated;
            this.OriginalTitle = movieDto.ImdbInfo?.OriginalTitle;
            this.Genre = movieDto.ImdbInfo?.Genres;
            this.ReleaseDate = movieDto.ImdbInfo?.ReleaseDate;
            this.RuntimeMins = movieDto.ImdbInfo?.RuntimeMins;
            this.RuntimeStr = movieDto.ImdbInfo?.RuntimeStr;
            this.Plot = movieDto.ImdbInfo?.Plot;
            this.PlotLocal = movieDto.ImdbInfo?.PlotLocal;
            this.Directors = movieDto.ImdbInfo?.Directors;
            this.Writer = movieDto.ImdbInfo?.Writers;
            this.Stars = movieDto.ImdbInfo?.Stars;
            this.Companies = movieDto.ImdbInfo?.Companies;
            this.Countries = movieDto.ImdbInfo?.Countries;
            this.Languages = movieDto.ImdbInfo?.Languages;
            this.Tagline = movieDto.ImdbInfo?.Tagline;
            this.Awards = movieDto.ImdbInfo?.Awards;
            this.EntertainmentId = id;
        }
    }
}
