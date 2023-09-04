using FilmFusion.Application.Dtos.File;

namespace FilmFusion.Application.Dtos.Models
{
    public class MovieBoxOfficeDto:BaseDto
    {
        public string? Budget { get; set; }
        public string? CumulativeWorldwideGross { get; set; }
        public string? OpeningWeekendUSA { get; set; }
        public string? GrossUSA { get; set; }

        public Guid EntertainmentId { get; set; }

        public MovieBoxOfficeDto(Guid id, MovieDto movieDto)
        {
            this.Id = Guid.NewGuid();
            this.Budget = movieDto.ImdbInfo?.BoxOffice?.Budget;
            this.CumulativeWorldwideGross = movieDto.ImdbInfo?.BoxOffice?.CumulativeWorldwideGross;
            this.OpeningWeekendUSA = movieDto.ImdbInfo?.BoxOffice?.OpeningWeekendUSA;
            this.GrossUSA = movieDto.ImdbInfo?.BoxOffice?.GrossUSA;
            this.EntertainmentId = id;
        }
    }
}
