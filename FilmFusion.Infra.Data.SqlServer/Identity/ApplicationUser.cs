using Microsoft.AspNet.Identity.EntityFramework;

namespace FilmFusion.Infra.Data.SqlServer.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? Name { get; set; }
        public string Email { get; set; }
    }
}
