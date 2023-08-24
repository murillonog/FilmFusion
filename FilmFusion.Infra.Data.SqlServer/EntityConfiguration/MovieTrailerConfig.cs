using FilmFusion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmFusion.Infra.Data.SqlServer.EntityConfiguration
{
    public class MovieTrailerConfig : IEntityTypeConfiguration<MovieTrailer>
    {
        public void Configure(EntityTypeBuilder<MovieTrailer> builder)
        {
            EntityBaseConfiguration<MovieTrailer>.Configure(builder);

            builder.Property(p => p.VideoId)
                .HasMaxLength(50);

            builder.Property(p => p.VideoTitle)
                .HasMaxLength(200);

            builder.Property(p => p.VideoDescription);

            builder.Property(p => p.ThumbnailUrl)
                .HasMaxLength(300);

            builder.Property(p => p.UploadDate)
                .HasMaxLength(20);

            builder.Property(p => p.Link)
                .HasMaxLength(200);

            builder.Property(p => p.LinkEmbed)
                .HasMaxLength(200);

            builder.Property(p => p.Ytvideo)
                .HasMaxLength(200);

            builder.HasOne(x => x.Entertainment)
                    .WithMany()
                    .HasForeignKey(x => x.EntertainmentId);
        }
    }
}
