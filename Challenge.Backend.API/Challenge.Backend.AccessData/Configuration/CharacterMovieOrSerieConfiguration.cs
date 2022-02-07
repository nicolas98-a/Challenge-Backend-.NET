using Challenge.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
