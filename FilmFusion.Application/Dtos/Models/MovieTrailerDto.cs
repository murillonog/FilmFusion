using FilmFusion.Application.Dtos.File;

namespace FilmFusion.Application.Dtos.Models
{
    public class MovieTrailerDto : BaseDto
    {       
        public string? VideoId { get; set; }
        public string? VideoTitle { get; set; }
        public string? VideoDescription { get; set; }
        public string? ThumbnailUrl { get; set; }
        public string? UploadDate { get; set; }
        public string? Link { get; set; }
        public string? LinkEmbed { get; set; }
        public string? Ytvideo { get; set; }

        public Guid EntertainmentId { get; set; }

        public MovieTrailerDto(Guid id, MovieDto movieDto)
        {
            this.Id = Guid.NewGuid();
            this.VideoId = movieDto.ImdbInfo?.Trailer?.VideoId;
            this.VideoTitle = movieDto.ImdbInfo?.Trailer?.VideoTitle;
            this.VideoDescription = movieDto.ImdbInfo?.Trailer?.VideoDescription;
            this.ThumbnailUrl = movieDto.ImdbInfo?.Trailer?.ThumbnailUrl;
            this.UploadDate = movieDto.ImdbInfo?.Trailer?.UploadDate;
            this.Link = movieDto.ImdbInfo?.Trailer?.Link;
            this.LinkEmbed = movieDto.ImdbInfo?.Trailer?.LinkEmbed;
            this.EntertainmentId = id;
        }
    }
}
