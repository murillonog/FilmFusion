namespace FilmFusion.Domain.Entities
{
    public class MovieDetail : EntityBase
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
        public Entertainment Entertainment { get; set; }
    }
}
