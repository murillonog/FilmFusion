namespace FilmFusion.Domain.Entities
{
    public class MovieRating : EntityBase
    {
        public string? TheMovieDb { get; set; }
        public string? RottenTomatoes { get; set; }
        public string? FilmAffinity { get; set; }
        public string? Metascore { get; set; }

        public Guid EntertainmentId { get; set; }
        public Entertainment Entertainment { get; set; }
    }
}
