using Challenge.Backend.Domain.DTOs;
using Challenge.Backend.Domain.Entities;
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
        GenericCreatedResponseDto CreateCharacter(CharacterRequestDto createCharacter);
        bool UpdateCharacter(int id, CharacterRequestDto characterRequestDto);
        bool DeleteCharacter(int id);
        ResponseCharacterDetailDto GetCharacterDetail(int id);
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

        public GenericCreatedResponseDto CreateCharacter(CharacterRequestDto createCharacter)
        {
            var entity = new Character
            {
                Image = createCharacter.Image,
                Name = createCharacter.Name,
                Age = createCharacter.Age,
                Weight = createCharacter.Weight,
                History = createCharacter.History
            };

            _repository.Add<Character>(entity);
            return new GenericCreatedResponseDto { Entity = "Character", Id = entity.CharacterId.ToString() };
        }

        public bool DeleteCharacter(int id)
        {
            Character character = _repository.Exists<Character>(id);
            if (character == null)
            {
                return false;
            }
            else
            {
                _repository.Delete<Character>(character);
                return true;
            }
        }

        public ResponseCharacterDetailDto GetCharacterDetail(int id)
        {
            ResponseCharacterDetailDto characterDetailById = _query.GetCharacterDetail(id);
            if (characterDetailById == null)
            {
                NullReferenceException exception = new NullReferenceException("Personaje con id " + id + " no encontrado");
                throw exception;
            }
            else
            {
                return characterDetailById;
            }
        }

        public List<ResponseGetAllCharacterDto> GetCharacters()
        {
            return _query.GetAllCharacters();
        }

        public bool UpdateCharacter(int id, CharacterRequestDto characterRequestDto)
        {
            Character character = _repository.Exists<Character>(id);
            if (character == null)
            {
                return false;
            }
            else
            {
                character.Image = characterRequestDto.Image;
                character.Name = characterRequestDto.Name;
                character.Age = characterRequestDto.Age;
                character.Weight = characterRequestDto.Weight;
                character.History = characterRequestDto.History;

                _repository.Update<Character>(character);
                return true;
            }

        }
    }
}
