using Challenge.Backend.AccessData.Configuration;
using Challenge.Backend.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
                                                   pg => {pg.HasKey(prop => new { prop.CharacterId, prop.MovieOrSerieId, prop.CharacterMovieOrSerieId }); });

            // Llamo al metodo que carga datos semilla para testeo de la base de datos
            builder.Seed();
        }

        private void ModelConfig(ModelBuilder builder)
        {
            new CharacterConfiguration(builder.Entity<Character>());
            new MovieOrSerieConfiguration(builder.Entity<MovieOrSerie>());
            new GenreConfiguratoin(builder.Entity<Genre>());
            new CharacterMovieOrSerieConfiguration(builder.Entity<CharacterMovieOrSerie>());
        }
    }

    public class DisneyDbContextFactory : IDesignTimeDbContextFactory<DisneyDbContext>
    {
        public DisneyDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DisneyDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=Disney_API_Db;Trusted_Connection=True;Integrated Security=True;;MultipleActiveResultSets=true");

            return new DisneyDbContext(optionsBuilder.Options);
        }
    }
}
