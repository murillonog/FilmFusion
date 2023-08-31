namespace FilmFusion.Tests.UseCases.Builder
{
    public class PathBuilder
    {
        public string PathName { get; set; }
        public PathBuilder(string pathName = "C:\\TempFilmFusion")
        {
            PathName = pathName;
            var tempPath = pathName;
            Directory.CreateDirectory(tempPath);

            var genrePath1 = Path.Combine(tempPath, "Drama");
            var genrePath2 = Path.Combine(tempPath, "Terror");
            Directory.CreateDirectory(genrePath1);
            Directory.CreateDirectory(genrePath2);

            var movie1 = Path.Combine(genrePath1, "12 Angry Men (1957) [ok] _ tt0050083");
            var movie2 = Path.Combine(genrePath1, "12 Mighty Orphans (2021) _ tt8482584");
            var movie3 = Path.Combine(genrePath2, "13 Cameras (2015) [ok] _ tt4392454");
            Directory.CreateDirectory(movie1);
            Directory.CreateDirectory(movie2);
            Directory.CreateDirectory(movie3);

            File.Create(Path.Combine(movie1, "12.Angry.Men.1957.720p.BRrip.x264.YIFY"));
            File.Create(Path.Combine(movie1, "12.Angry.Men.1957.720p.BRrip.x264.YIFY.srt"));
            File.Create(Path.Combine(movie2, "12.Mighty.Orphans.2021.720p.BluRay.x264.AAC-[YTS.MX]"));
            File.Create(Path.Combine(movie2, "12.Mighty.Orphans.2021.720p.BluRay.x264.AAC-[YTS.MX].srt"));
            File.Create(Path.Combine(movie3, "13 Cameras.2015.HDRip.XViD-ETRG"));
            File.Create(Path.Combine(movie3, "13 Cameras.2015.HDRip.XViD-ETRG.srt"));
        }
    }
}
