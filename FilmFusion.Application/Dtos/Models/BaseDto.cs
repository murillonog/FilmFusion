namespace FilmFusion.Application.Dtos.Models
{
    public abstract class BaseDto
    {
        public Guid Id { get; protected set; }
        public string CreatedBy { get; set; }
        public DateTime? Created { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? Modified { get; set; }
    }
}
