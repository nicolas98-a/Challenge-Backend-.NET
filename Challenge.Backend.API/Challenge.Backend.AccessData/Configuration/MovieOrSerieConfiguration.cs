using Challenge.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Challenge.Backend.AccessData.Configuration
{
    public class MovieOrSerieConfiguration
    {
        public MovieOrSerieConfiguration(EntityTypeBuilder<MovieOrSerie> entityTypeBuilder)
        {
            entityTypeBuilder.HasIndex(x => x.MovieOrSerieId);
            entityTypeBuilder.Property(x => x.Image).IsRequired();
            entityTypeBuilder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            entityTypeBuilder.Property(x => x.CreationDate).IsRequired();
            entityTypeBuilder.Property(x => x.Rating).IsRequired();
        }
    }
}
