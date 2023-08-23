namespace FilmFusion.Domain.Entities
{
    public class MovieDirectory : EntityBase
    {
        public string RootPath { get; set; }
        public string MoviePath { get; set; }
        public string SubtitlePath { get; set; }

        public int Size { get; set; }
        public string Extension { get; set; }

        public string? ImdbPath { get; set; }
        public string? OmdbPath { get; set; }
        public string? DetailsPath { get; set; }

        public Guid EntertainmentId { get; set; }
        public Entertainment Entertainment { get; set; }
    }
}
