using IMDbApiLib.Models;

namespace FilmFusion.Application.Dtos.Models
{
    public class MovieBackdropDto : BaseDto
    {
        public string? Link { get; set; }
        public double? AspectRatio { get; set; }
        public string? Language { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }

        public Guid EntertainmentId { get; set; }

        public MovieBackdropDto(Guid id, PosterDataItem poster)
        {
            this.Id = Guid.NewGuid();
            this.Link = poster.Link;
            this.AspectRatio = poster.AspectRatio;
            this.Language = poster.Language;
            this.Width = poster.Width;
            this.Height = poster.Height;
            this.EntertainmentId = id;
        }
    }
}
