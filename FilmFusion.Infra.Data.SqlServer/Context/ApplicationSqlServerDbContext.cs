using FilmFusion.Domain.Entities;
using FilmFusion.Infra.Data.SqlServer.EntityConfiguration;
using FilmFusion.Infra.Data.SqlServer.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FilmFusion.Infra.Data.SqlServer.Context
{
    public class ApplicationSqlServerDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationSqlServerDbContext(DbContextOptions<ApplicationSqlServerDbContext> options) : base(options)
        {
        }

        #region[Main]
        public DbSet<Entertainment> Entertainments { get; set; }
        #endregion

        #region[Movie]
        public DbSet<MovieDetail> MovieDetails { get; set; }
        public DbSet<MovieRating> MovieRatings { get; set; }
        public DbSet<MovieTrailer> MovieTrailers { get; set; }
        public DbSet<MovieBoxOffice> MovieBoxOffices { get; set; }
        public DbSet<MovieBackdrop> MovieBackdrops { get; set; }
        public DbSet<MoviePoster> MoviePosters { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region [Configurations]
            modelBuilder.ApplyConfiguration(new EntertainmentConfig());
            modelBuilder.ApplyConfiguration(new MovieDetailConfig());
            modelBuilder.ApplyConfiguration(new MovieBoxOfficeConfig());
            modelBuilder.ApplyConfiguration(new MovieRatingConfig());
            modelBuilder.ApplyConfiguration(new MovieTrailerConfig());
            modelBuilder.ApplyConfiguration(new MovieBackdropConfig());
            modelBuilder.ApplyConfiguration(new MoviePosterConfig());
            #endregion

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationSqlServerDbContext).Assembly);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is EntityBase && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                if (entityEntry.State == EntityState.Added)
                {
                    ((EntityBase)entityEntry.Entity).Created = DateTime.Now;
                    if (string.IsNullOrEmpty(((EntityBase)entityEntry.Entity).CreatedBy))
                        ((EntityBase)entityEntry.Entity).CreatedBy = "murilloAdmin";
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    ((EntityBase)entityEntry.Entity).Modified = DateTime.Now;
                }
            }

            return await base.SaveChangesAsync();
        }
    }
}
