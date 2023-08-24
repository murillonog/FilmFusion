using FilmFusion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmFusion.Infra.Data.SqlServer.EntityConfiguration
{
    public class MovieRatingConfig : IEntityTypeConfiguration<MovieRating>
    {
        public void Configure(EntityTypeBuilder<MovieRating> builder)
        {
            EntityBaseConfiguration<MovieRating>.Configure(builder);

            builder.Property(p => p.TheMovieDb)
                    .HasMaxLength(5);

            builder.Property(p => p.RottenTomatoes)
                    .HasMaxLength(5);

            builder.Property(p => p.FilmAffinity)
                    .HasMaxLength(5);

            builder.Property(p => p.Metascore)
                    .HasMaxLength(5);

            builder.HasOne(x => x.Entertainment)
                    .WithMany()
                    .HasForeignKey(x => x.EntertainmentId);
        }
    }
}
