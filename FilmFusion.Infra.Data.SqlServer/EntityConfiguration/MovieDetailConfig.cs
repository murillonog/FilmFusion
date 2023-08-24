using FilmFusion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmFusion.Infra.Data.SqlServer.EntityConfiguration
{
    public class MovieDetailConfig : IEntityTypeConfiguration<MovieDetail>
    {
        public void Configure(EntityTypeBuilder<MovieDetail> builder)
        {
            EntityBaseConfiguration<MovieDetail>.Configure(builder);

            builder.Property(p => p.Rated)
                    .HasMaxLength(10);

            builder.Property(p => p.OriginalTitle)
                    .HasMaxLength(104);

            builder.Property(p => p.Genre)
                    .HasMaxLength(150);

            builder.Property(p => p.ReleaseDate)
                    .HasMaxLength(20);

            builder.Property(p => p.RuntimeMins)
                    .HasMaxLength(10);

            builder.Property(p => p.RuntimeStr)
                    .HasMaxLength(20);

            builder.Property(p => p.Plot);

            builder.Property(p => p.PlotLocal);

            builder.Property(p => p.Directors)
                .HasMaxLength(300);

            builder.Property(p => p.Writer);

            builder.Property(p => p.Stars)
                    .HasMaxLength(500);

            builder.Property(p => p.Companies)
                    .HasMaxLength(300);

            builder.Property(p => p.Countries)
                    .HasMaxLength(200);

            builder.Property(p => p.Languages)
                    .HasMaxLength(200);

            builder.Property(p => p.Tagline)
                    .HasMaxLength(500);

            builder.Property(p => p.Awards)
                    .HasMaxLength(300);

            builder.HasOne(x => x.Entertainment)
                    .WithMany()
                    .HasForeignKey(x => x.EntertainmentId);
        }
    }
}
