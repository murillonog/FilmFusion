using FilmFusion.Application.Dtos.File;

namespace FilmFusion.Application.Dtos.Models
{
    public class EntertainmentDto : BaseDto
    {
        public string? ImdbRating { get; set; }
        public string? ImdbVotes { get; set; }
        public string? ImdbId { get; set; }
        public string? Title { get; set; }
        public string? Year { get; set; }
        public string? FullTitle { get; set; }
        public string? Image { get; set; }
        public string? Poster { get; set; }
        public string Type { get; set; }
        public bool IsWatched { get; set; }

        public MovieDirectoryDto? Directory { get; set; }
        public MovieDetailDto? Detail { get; set; }
        public MovieRatingDto? Rating { get; set; }
        public MovieBoxOfficeDto? BoxOffice { get; set; }
        public MovieTrailerDto? Trailer { get; set; }
        public ICollection<MoviePosterDto>? Posters { get; set; }
        public ICollection<MovieBackdropDto>? Backdrops { get; set; }

        public EntertainmentDto(MovieDirectoryDto movieDirectoryDto)
        {
            MovieDto movieDto = System.Text.Json.JsonSerializer.Deserialize<MovieDto>(System.IO.File.ReadAllText(movieDirectoryDto.DetailsPath));
            
            this.Id = Guid.NewGuid();
            this.ImdbRating = movieDto.ImdbInfo?.IMDbRating;
            this.ImdbVotes = movieDto.ImdbInfo?.IMDbRatingVotes;
            this.ImdbId = movieDto.ImdbId;
            this.Title = movieDto.Title;
            this.Year = movieDto.Year;
            this.IsWatched = movieDto.IsWatched;
            this.FullTitle = movieDto.ImdbInfo?.FullTitle;
            this.Image = movieDto.ImdbInfo?.Image;
            this.Poster = movieDto.OmdbInfo?.Poster;
            this.Type = "movie";
            this.Directory = new MovieDirectoryDto(this.Id, movieDirectoryDto);
            this.Detail = new MovieDetailDto(this.Id, movieDto);
            this.Rating = new MovieRatingDto(this.Id, movieDto);
            this.BoxOffice = new MovieBoxOfficeDto(this.Id, movieDto);
            this.Trailer = new MovieTrailerDto(this.Id, movieDto);

            if(movieDto.ImdbInfo.Posters != null)
            {
                this.Posters = new List<MoviePosterDto>();
                foreach (var poster in movieDto.ImdbInfo.Posters.Posters)
                    this.Posters.Add(new MoviePosterDto(this.Id, poster));
                
                this.Backdrops = new List<MovieBackdropDto>();
                foreach (var backdrops in movieDto.ImdbInfo.Posters.Backdrops)
                    this.Backdrops.Add(new MovieBackdropDto(this.Id, backdrops));
            }
        }
    }
}
