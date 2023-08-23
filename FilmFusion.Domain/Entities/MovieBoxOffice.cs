namespace FilmFusion.Domain.Entities
{
    public class MovieBoxOffice : EntityBase
    {
        public string? Budget { get; set; }
        public string? CumulativeWorldwideGross { get; set; }
        public string? OpeningWeekendUSA { get; set; }
        public string? GrossUSA { get; set; }

        public Guid EntertainmentId { get; set; }
        public Entertainment Entertainment { get; set; }
    }
}
