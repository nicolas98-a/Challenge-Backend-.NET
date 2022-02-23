using Challenge.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Challenge.Backend.AccessData.Configuration
{
    public class CharacterConfiguration
    {
        public CharacterConfiguration(EntityTypeBuilder<Character> entityTypeBuilder)
        {
            entityTypeBuilder.HasIndex(x => x.CharacterId);
            entityTypeBuilder.Property(x => x.Image).IsRequired();
            entityTypeBuilder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            entityTypeBuilder.Property(x => x.Age).IsRequired();
            entityTypeBuilder.Property(x => x.Weight).IsRequired();
            entityTypeBuilder.Property(x => x.History).IsRequired();
        }
    }
}
