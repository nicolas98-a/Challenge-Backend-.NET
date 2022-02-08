using Challenge.Backend.Domain.DTOs;
using Challenge.Backend.Domain.ICommands;
using Challenge.Backend.Domain.IQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Backend.Application.Services
{
    public interface ICharacterService
    {
        List<ResponseGetAllCharacterDto> GetCharacters();
    }
    public class CharacterService : ICharacterService
    {
        private readonly IGenericsRepository _repository;
        private readonly ICharacterQuery _query;

        public CharacterService(IGenericsRepository repository, ICharacterQuery query)
        {
            _repository = repository;
            _query = query;
        }

        public List<ResponseGetAllCharacterDto> GetCharacters()
        {
            return _query.GetAllCharacters();
        }
    }
}
