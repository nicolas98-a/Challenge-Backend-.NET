using Challenge.Backend.Domain.DTOs;
using Challenge.Backend.Domain.IQueries;
using SqlKata.Compilers;
using SqlKata.Execution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
