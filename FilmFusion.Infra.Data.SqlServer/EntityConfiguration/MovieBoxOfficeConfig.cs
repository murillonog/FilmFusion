using FilmFusion.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FilmFusion.Infra.Data.SqlServer.EntityConfiguration
{
    public class MovieBoxOfficeConfig : IEntityTypeConfiguration<MovieBoxOffice>
    {
        public void Configure(EntityTypeBuilder<MovieBoxOffice> builder)
        {
            EntityBaseConfiguration<MovieBoxOffice>.Configure(builder);

            builder.Property(p => p.Budget)
                    .HasMaxLength(50);

            builder.Property(p => p.CumulativeWorldwideGross)
                    .HasMaxLength(50);

            builder.Property(p => p.OpeningWeekendUSA)
                    .HasMaxLength(50);

            builder.Property(p => p.GrossUSA)
                    .HasMaxLength(50);

            builder.HasOne(x => x.Entertainment)
                    .WithMany()
                    .HasForeignKey(x => x.EntertainmentId);
        }
    }
}
