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

        public CharacterQuery(IDbConnection connection, Compiler sqlKataCompiler)
        {
            this.connection = connection;
            this.sqlKataCompiler = sqlKataCompiler;
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
    }
}
