using Challenge.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Backend.AccessData.Configuration
{
    public class GenreConfiguratoin
    {
        public GenreConfiguratoin(EntityTypeBuilder<Genre> entityTypeBuilder)
        {
            entityTypeBuilder.HasIndex(x => x.GenreId);
            entityTypeBuilder.Property(x => x.Image).IsRequired();
            entityTypeBuilder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        }
    }
}
