namespace FilmFusion.Application.Dtos.Models
{
    public class MovieDirectoryDto : BaseDto
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string ImdbId { get; set; }
        public bool IsWatched { get; set; }

        public string RootPath { get; set; }
        public string MoviePath { get; set; }
        public string SubtitlePath { get; set; }

        public int Size { get; set; }
        public string Extension { get; set; }

        public string? ImdbPath { get; set; }
        public string? OmdbPath { get; set; }
        public string? DetailsPath { get; set; }
        public string? ErrorMessage { get; set; }

        public Guid EntertainmentId { get; set; }
        public MovieDirectoryDto() { }

        public MovieDirectoryDto(Guid id, MovieDirectoryDto movieDirectoryDto)
        {
            this.Id = Guid.NewGuid();
            this.Title = movieDirectoryDto.Title;
            this.Year = movieDirectoryDto.Year;
            this.ImdbId = movieDirectoryDto.ImdbId;
            this.IsWatched = movieDirectoryDto.IsWatched;
            this.RootPath = movieDirectoryDto.RootPath;
            this.MoviePath = movieDirectoryDto.MoviePath;
            this.SubtitlePath = movieDirectoryDto.SubtitlePath;
            this.Size = movieDirectoryDto.Size;
            this.Extension = movieDirectoryDto.Extension;
            this.ImdbPath = movieDirectoryDto.ImdbPath;
            this.OmdbPath = movieDirectoryDto.OmdbPath;
            this.DetailsPath = movieDirectoryDto.DetailsPath;
            this.ErrorMessage = movieDirectoryDto.ErrorMessage;
            this.EntertainmentId = id;
        }
    }
}
