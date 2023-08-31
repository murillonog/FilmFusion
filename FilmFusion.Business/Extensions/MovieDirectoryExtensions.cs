using FilmFusion.Domain.Entities;

namespace FilmFusion.Business.Extensions
{
    public static class MovieDirectoryExtensions
    {
        public static MovieDirectory FromDirectory(string movie)
        {
            var txt = movie.Split('\\')[3];
            var directoryMovie = Directory.GetFiles(movie);

            return new MovieDirectory()
            {
                Title = txt.Split('(', ')')[0].Trim(),
                Year = txt.Split('(', ')')[1].Trim(),
                ImdbId = txt.Split('_')[1].Trim(),
                IsWatched = txt.Contains("[ok]"),

                RootPath = movie,
                MoviePath = directoryMovie.FirstOrDefault(c => !c.Contains(".vtt") && !c.Contains(".srt")) != null ? directoryMovie.FirstOrDefault(c => !c.Contains(".vtt") && !c.Contains(".srt")).Replace("\\", "//").Remove(0, 2) : string.Empty,
                SubtitlePath = directoryMovie.Any(c => c.Contains(".vtt")) ? directoryMovie.FirstOrDefault(c => c.Contains(".vtt")).Replace("\\", "//").Remove(0, 4) : string.Empty,

                Size = Convert.ToInt32((new FileInfo(directoryMovie.FirstOrDefault(c => !c.Contains(".vtt") && !c.Contains(".srt")))).Length / 1024) / 1024,
                Extension = Path.GetExtension(directoryMovie.FirstOrDefault(c => !c.Contains(".vtt") && !c.Contains(".srt"))).Replace(".", ""),

                ImdbPath = directoryMovie.FirstOrDefault(c => c.Contains("zz_imdb")),
                OmdbPath = directoryMovie.FirstOrDefault(c => c.Contains("zz_omdb")),
                DetailsPath = directoryMovie.FirstOrDefault(c => c.Contains("_details"))
            };
        }
    }
}
