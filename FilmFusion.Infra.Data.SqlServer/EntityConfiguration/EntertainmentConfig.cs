using FilmFusion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmFusion.Infra.Data.SqlServer.EntityConfiguration
{
    public class EntertainmentConfig : IEntityTypeConfiguration<Entertainment>
    {
        public void Configure(EntityTypeBuilder<Entertainment> builder)
        {
            EntityBaseConfiguration<Entertainment>.Configure(builder);

            builder.Property(e => e.Title)
                    .HasMaxLength(100);

            builder.Property(e => e.Year)
                    .HasMaxLength(4);

            builder.Property(e => e.FullTitle)
                    .HasMaxLength(104);

            builder.Property(e => e.Image)
                    .HasMaxLength(200);

            builder.Property(e => e.Poster)
                    .HasMaxLength(200);

            builder.Property(e => e.ImdbId)
                    .HasMaxLength(20);

            builder.Property(e => e.ImdbVotes)
                    .HasMaxLength(20);

            builder.Property(e => e.ImdbRating)
                    .HasMaxLength(8);

            builder.Property(e => e.Type)
                    .HasMaxLength(10);

            builder.Property(e => e.IsWatched);
        }
    }
}
