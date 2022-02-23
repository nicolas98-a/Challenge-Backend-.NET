using Challenge.Backend.Domain.DTOs;
using Challenge.Backend.Domain.IQueries;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Challenge.Backend.AccessData.Queries
{
    public class MovieOrSerieQuery : IMovieOrSerieQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;

        public MovieOrSerieQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
        }

        public List<ResponseGetAllMovieOrSerieDto> GetAllMovieOrSeries()
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("MovieOrSeries")
                .Select("MovieOrSeries.Image",
                "MovieOrSeries.Title",
                "MovieOrSeries.CreationDate");
            var result = query.Get<ResponseGetAllMovieOrSerieDto>();
            return result.ToList();
        }

        public ResponseMovieOrSerieDetailDto GetMovieOrSerieDetail(int id)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);
            var movie = db.Query("MovieOrSeries")
                .Select("MovieOrSeries.Image",
                "MovieOrSeries.Title",
                "MovieOrSeries.CreationDate",
                "MovieOrSeries.Rating",
                "MovieOrSeries.GenreId")
                .Where("MovieOrSeries.MovieOrSerieId", "=", id)
                .FirstOrDefault<MovieOrSerieDto>();
            if (movie != null)
            {
                var genre = db.Query("Genres")
                    .Select("Genres.GenreId", "Genres.Name")
                    .Where("Genres.GenreId", "=", movie.GenreId)
                    .FirstOrDefault<ResponseGetMovieDetailGenre>();

                var idsCharacters = db.Query("CharacterMovieOrSeries")
                    .Select("CharacterId")
                    .Where("MovieOrSerieId", "=", id)
                    .Get<int>().ToList();

                List<ResponseCharacterForMovieOrSerieDetail> listMoviesSeries = new List<ResponseCharacterForMovieOrSerieDetail>();
                foreach (var item in idsCharacters)
                {
                    ResponseCharacterForMovieOrSerieDetail character = GetCharacterForMovieOrSerieDetail(item);
                    listMoviesSeries.Add(character);
                }

                return new ResponseMovieOrSerieDetailDto
                {
                    Image = movie.Image,
                    Title = movie.Title,
                    CreationDate = movie.CreationDate,
                    Rating = movie.Rating,
                    Genre = genre.Name,
                    Characters = listMoviesSeries
                };
            }
            else
            {
                return null;
            }
        }

        private ResponseCharacterForMovieOrSerieDetail GetCharacterForMovieOrSerieDetail(int id)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var character = db.Query("Characters")
                .Select("Characters.CharacterId",
                "Characters.Image",
                "Characters.Name",
                "Characters.Age",
                "Characters.Weight",
                "Characters.History")
                .Where("Characters.CharacterId", "=", id)
                .FirstOrDefault<ResponseCharacterForMovieOrSerieDetail>();
            if (character != null)
            {
                return character;
            }
            else
            {
                return null;
            }
        }

        public ResponseMovieOrSerieForCharacterDetail GetMoviesOrSeriesById(int id)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);
            var query = db.Query("MovieOrSeries")
                .Select("MovieOrSeries.Image",
                "MovieOrSeries.Title",
                "MovieOrSeries.CreationDate")
                .Where("MovieOrSeries.MovieOrSerieId", "=", id)
                .FirstOrDefault<ResponseMovieOrSerieForCharacterDetail>();

            if (query != null)
            {
                return query;
            }
            else
            {
                return null;
            }
        }

        public List<ResponseGetAllMovieOrSerieDto> GetMoviesOrSeriesByName(string name)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("MovieOrSeries")
                .Select("MovieOrSeries.Image",
                "MovieOrSeries.Title",
                "MovieOrSeries.CreationDate")
                .Where("MovieOrSeries.Title", "=", name);
            var result = query.Get<ResponseGetAllMovieOrSerieDto>();
            return result.ToList();
        }

        public List<ResponseGetAllMovieOrSerieDto> GetMoviesOrSeriesByGenreId(string idGenre)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("MovieOrSeries")
                .Select("MovieOrSeries.Image",
                "MovieOrSeries.Title",
                "MovieOrSeries.CreationDate")
                .Where("MovieOrSeries.GenreId", "=", idGenre);
            var result = query.Get<ResponseGetAllMovieOrSerieDto>();
            return result.ToList();
        }

        public List<ResponseGetAllMovieOrSerieDto> GetMoviesOrSeriesByOrder(string order)
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            if (order == "ASC" || order == "asc")
            {
                var query = db.Query("MovieOrSeries")
                .Select("MovieOrSeries.Image",
                "MovieOrSeries.Title",
                "MovieOrSeries.CreationDate")
                .OrderBy("MovieOrSeries.CreationDate");
                var result = query.Get<ResponseGetAllMovieOrSerieDto>();
                return result.ToList();
            }
            else
            {
                var query = db.Query("MovieOrSeries")
                .Select("MovieOrSeries.Image",
                "MovieOrSeries.Title",
                "MovieOrSeries.CreationDate")
                .OrderByDesc("MovieOrSeries.CreationDate");
                var result = query.Get<ResponseGetAllMovieOrSerieDto>();
                return result.ToList();
            }       
        }
    }
}
