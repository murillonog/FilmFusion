using FilmFusion.Domain.File;
using System.Text.Json;

namespace FilmFusion.Application.Utils
{
    public class WriterText
    {
        public WriterText(string path)
        {
            Path = path;
        }
        public string Path { get; set; }


        internal void WriterMovieDetails(Movie movie)
        {
            if (File.Exists(Path))
                File.Delete(Path);

            var text = JsonSerializer.Serialize<Movie>(movie, new JsonSerializerOptions { WriteIndented = true });
            using FileStream fileStream = new FileStream(Path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            using StreamWriter file = new StreamWriter(fileStream);
            file.WriteLine(text);
            file.Close();
        }
    }
}
