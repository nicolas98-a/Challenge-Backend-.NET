using Challenge.Backend.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Backend.AccessData
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region Carga de personajes para testeo de la database

            var characters = new List<Character>();

            characters.Add(new Character 
            {
                CharacterId = 1,
                Image = "https://static.wikia.nocookie.net/disney/images/8/85/Aladdin_%28personaje%29.png/revision/latest/scale-to-width-down/358?cb=20160318010334&path-prefix=es",
                Name = "Aladdin", 
                Age = 25,
                Weight = 85,
                History = "Aladdín vive en una guarida en el bazar de Ágrabah con su mono Abú, y sueña con vivir lleno de lujos. Cuando conoce a Jasmín él no sabe que ella es la princesa, aunque él se enamora de ella. Cuando lo descubre, piensa que nunca conseguirá gustarle, pero un anciano (el cual es en realidad el Gran Visir Jafar), le ofrece el trato de conseguir todo tipo de fortunas con la ayuda de la Lámpara de la Cueva de las Maravillas, cuando Aladdín consigue la lámpara, el anciano le traiciona y le arroja a la cueva, pero Abú consiguió quitarle la Lámpara al anciano. Cuando Aladdín frota la lámpara, de ella aparece un Genio, el cual le concede tres deseos. Así que Aladdín desea que le convierta en príncipe."
            });
            characters.Add(new Character
            {
                CharacterId = 2,
                Image = "https://static.wikia.nocookie.net/disney/images/3/3a/20200401_135153.jpg/revision/latest/scale-to-width-down/1000?cb=20200401115358&path-prefix=es",
                Name = "Genio",
                Age = 100000,
                Weight = 100,
                History = "Genio es el tritagonista de la película Aladdín. Es un Genio, un espíritu cómico, muy poderoso, que actúa como un sirviente de quien tiene la propiedad de la Lámpara Mágica en la que reside."
            });
            characters.Add(new Character
            {
                CharacterId = 3,
                Image = "https://static.wikia.nocookie.net/disney/images/9/95/Simba.png/revision/latest/scale-to-width-down/317?cb=20121008182056&path-prefix=es",
                Name = "Simba",
                Age = 10,
                Weight = 100,
                History = " Hijo de Mufasa y Sarabi, Simba fue el siguiente a su padre en la línea para gobernar las Tierras del Reino. Sin embargo, después de que su malvado tío Scar asesinó a Mufasa y culpó a Simba por la muerte del antiguo rey, el joven cachorro de león es condenado al exilio mientras que Scar gobierna como rey. Fue entonces cuando Simba regresó a las Tierras del Reino y reclamó su trono y lugar legítimo en el gran ciclo de la vida."
            });

            modelBuilder.Entity<Character>().HasData(characters);
            #endregion

            #region Carga de peliculas o series para testeo de la database

            var moviesOrSeries = new List<MovieOrSerie>();

            moviesOrSeries.Add(new MovieOrSerie
            {
                MovieOrSerieId = 1,
                Image = "https://static.wikia.nocookie.net/disney/images/3/32/Aladdin-ATKOT.png/revision/latest/scale-to-width-down/245?cb=20140721083213&path-prefix=es",
                Title = "Aladdín y el Rey de los Ladrones ",
                CreationDate = DateTime.Parse("1996-8-13"),
                Rating = 4, 
                GenreId = 1
            });
            moviesOrSeries.Add(new MovieOrSerie
            {
                MovieOrSerieId = 2,
                Image = "https://static.wikia.nocookie.net/disney/images/1/1a/Lion_king_ver5_xlg.jpg/revision/latest/scale-to-width-down/1000?cb=20160923051934&path-prefix=es",
                Title = "El Rey León",
                CreationDate = DateTime.Parse("1994-7-7"),
                Rating = 5,
                GenreId = 2
            });
            moviesOrSeries.Add(new MovieOrSerie
            {
                MovieOrSerieId = 3,
                Image = "https://static.wikia.nocookie.net/disney/images/4/43/The_Lion_Guard_Logo.png/revision/latest/scale-to-width-down/360?cb=20160926192441&path-prefix=es",
                Title = "La Guardia del León",
                CreationDate = DateTime.Parse("2016-1-15"),
                Rating = 3,
                GenreId = 2
            });

            modelBuilder.Entity<MovieOrSerie>().HasData(moviesOrSeries);

            #endregion 

            #region Carga de la tabla intermedia de personajes y peliculas para testeo de la database

            modelBuilder.Entity<CharacterMovieOrSerie>().HasData(
                new CharacterMovieOrSerie { CharacterMovieOrSerieId = 1, CharacterId = 1, MovieOrSerieId = 1 },
                new CharacterMovieOrSerie { CharacterMovieOrSerieId = 2, CharacterId = 2, MovieOrSerieId = 1 },
                new CharacterMovieOrSerie { CharacterMovieOrSerieId = 3, CharacterId = 3, MovieOrSerieId = 2 },
                new CharacterMovieOrSerie { CharacterMovieOrSerieId = 4, CharacterId = 3, MovieOrSerieId = 3 });
            #endregion

            #region Carga generos para testeo de la database

            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = 1, Image = "https://i0.wp.com/xn--oo-yjab.cl/wp-content/uploads/2013/11/wonderland-pais-de-las-maravillas-alicia.jpg?resize=662%2C326&ssl=1", Name = "Fantasía" },
                new Genre { GenreId = 2, Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR3JtHmv6mxkhmizikfV1ywAgWQouCnjEyPmg&usqp=CAU", Name = "Aventura" });
            #endregion
        }
    }
}
