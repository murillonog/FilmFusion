using FilmFusion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmFusion.Infra.Data.SqlServer.EntityConfiguration
{
    public class MovieBackdropConfig : IEntityTypeConfiguration<MovieBackdrop>
    {
        public void Configure(EntityTypeBuilder<MovieBackdrop> builder)
        {
            EntityBaseConfiguration<MovieBackdrop>.Configure(builder);

            builder.Property(p => p.Link)
                    .HasMaxLength(150);

            builder.Property(p => p.Language)
                    .HasMaxLength(15);

            builder.Property(p => p.Width);

            builder.Property(p => p.Height);

            builder.Property(p => p.AspectRatio);

            builder.HasOne(x => x.Entertainment)
                    .WithMany(x => x.Backdrops)
                    .HasForeignKey(x => x.EntertainmentId);
        }
    }
}
