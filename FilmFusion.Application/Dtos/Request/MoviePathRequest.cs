namespace FilmFusion.Application.Dtos.Request
{
    public class MoviePathRequest
    {
        public string Path { get; set; }

        public MoviePathRequest(string path)
        {
            Path = path;
        }
        public MoviePathRequest()
        {

        }
    }
}
