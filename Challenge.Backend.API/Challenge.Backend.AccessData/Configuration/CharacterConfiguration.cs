using Challenge.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Backend.AccessData.Configuration
{
    public class CharacterConfiguration
    {
        public CharacterConfiguration(EntityTypeBuilder<Character> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.CharacterId);
            entityBuilder.Property(x => x.Image).IsRequired();
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            entityBuilder.Property(x => x.Age).IsRequired();
            entityBuilder.Property(x => x.Weight).IsRequired();
            entityBuilder.Property(x => x.History).IsRequired().HasMaxLength(250);

            #region Carga de personajes para testeo de la database

            var characters = new List<Character>();

            characters.Add(new Character { CharacterId = 1, Image = "", Name = "", Age = 1, Weight = 1, History = "" });

            entityBuilder.HasData(characters);
            #endregion
        }
    }
}
