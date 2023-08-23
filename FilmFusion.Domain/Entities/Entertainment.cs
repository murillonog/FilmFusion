namespace FilmFusion.Domain.Entities
{
    public class Entertainment : EntityBase
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

        public MovieDirectory? Directory { get; set; }
        public MovieDetail? Detail { get; set; }
        public MovieRating? Rating { get; set; }
        public MovieBoxOffice? BoxOffice { get; set; }
        public MovieTrailer? Trailer { get; set; }
        public ICollection<MoviePoster>? Posters { get; set; }
        public ICollection<MovieBackdrop>? Backdrops { get; set; }
    }
}
