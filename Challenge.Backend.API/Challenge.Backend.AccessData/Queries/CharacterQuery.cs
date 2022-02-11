using Challenge.Backend.Application.Services;
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
    public class CharacterQuery : ICharacterQuery
    {
        private readonly IDbConnection connection;
        private readonly Compiler sqlKataCompiler;
        private readonly IMovieOrSerieService _movieOrSerieService;

        public CharacterQuery(IDbConnection connection, Compiler sqlKataCompiler, IMovieOrSerieService movieOrSerieService)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
            _movieOrSerieService = movieOrSerieService;
        }

        public List<ResponseGetAllCharacterDto> GetAllCharacters()
        {
            var db = new QueryFactory(connection, sqlKataCompiler);

            var query = db.Query("Characters")
                .Select("Characters.Image",
                "Characters.Name");
            var result = query.Get<ResponseGetAllCharacterDto>();
            return result.ToList();
        }

        public ResponseCharacterDetailDto GetCharacterDetail(int id)
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
                .FirstOrDefault<CharacterDto>();

            if (character != null)
            {
                var idsMoviesOrSeries = db.Query("CharacterMovieOrSeries")
                    .Select("MovieOrSerieId")
                    .Where("CharacterId", "=", id)
                    .Get<int>().ToList();

                List<ResponseMovieOrSerieForCharacterDetail> listMoviesOrSeries = new List<ResponseMovieOrSerieForCharacterDetail>();
                foreach (var item in idsMoviesOrSeries)
                {
                    ResponseMovieOrSerieForCharacterDetail responseMovieOrSerie = _movieOrSerieService.GetMovieOrSerieById(item);
                    listMoviesOrSeries.Add(responseMovieOrSerie);
                }

                return new ResponseCharacterDetailDto
                {
                    CharacterId = character.CharacterId,
                    Image = character.Image,
                    Name = character.Name,
                    Age = character.Age,
                    Weight = character.Weight,
                    History = character.History,
                    MovieOrSeries = listMoviesOrSeries
                };
            }
            else
            {
                return null;
            }
        }
    }
}
