using Challenge.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Challenge.Backend.AccessData.Configuration
{
    public class CharacterMovieOrSerieConfiguration
    {
        public CharacterMovieOrSerieConfiguration(EntityTypeBuilder<CharacterMovieOrSerie> entityTypeBuilder)
        {
            entityTypeBuilder.Property(x => x.CharacterMovieOrSerieId).ValueGeneratedOnAdd();
        }
    }
}
