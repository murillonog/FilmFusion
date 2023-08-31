namespace FilmFusion.Application.Dtos.Response
{
    public class MoviePathResponse
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
    }
}
