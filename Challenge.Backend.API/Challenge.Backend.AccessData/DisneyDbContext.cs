using Challenge.Backend.AccessData.Configuration;
using Challenge.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Backend.AccessData
{
    public class DisneyDbContext : DbContext
    {
        public DisneyDbContext(DbContextOptions<DisneyDbContext> options) : base(options)
        { }

        public DbSet<Character> Characters { get; set; }
        public DbSet<MovieOrSerie> MovieOrSeries { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<CharacterMovieOrSerie> CharacterMovieOrSeries { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Model Contraints
            ModelConfig(builder);

            builder.Entity<Character>().HasMany(m => m.MovieOrSeriesNavigator).WithMany(c => c.CharactersNavigator)
                                               .UsingEntity<CharacterMovieOrSerie>(
                                                   cm => cm.HasOne(prop => prop.MovieOrSerieNavigator).WithMany().HasForeignKey(prop => prop.MovieOrSerieId),
                                                   pg => pg.HasOne(prop => prop.CharacterNavigator).WithMany().HasForeignKey(prop => prop.CharacterId),
                                                   pg => { pg.HasKey(prop => new { prop.CharacterId, prop.MovieOrSerieId, prop.CharacterMovieOrSerieId }); });

        }

        private void ModelConfig(ModelBuilder builder)
        {
            new CharacterConfiguration(builder.Entity<Character>());
        }
    }
}
