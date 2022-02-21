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
        List<ResponseGetAllCharacterDto> GetCharactersByName(string name);
        List<ResponseGetAllCharacterDto> GetCharactersByAge(string age);
        List<ResponseGetAllCharacterDto> GetCharactersByIdMovie(string idMovie);
        GenericCreatedResponseDto CreateCharacter(CreateCharacterRequestDto createCharacter);
        bool UpdateCharacter(int id, CreateCharacterRequestDto characterRequestDto);
        bool DeleteCharacter(int id);
        ResponseCharacterDetailDto GetCharacterDetail(int id);
       // ResponseCharacterForMovieOrSerieDetail GetCharacterById(int id);

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

        public GenericCreatedResponseDto CreateCharacter(CreateCharacterRequestDto createCharacter)
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
/*
        public ResponseCharacterForMovieOrSerieDetail GetCharacterById(int id)
        {
            ResponseCharacterForMovieOrSerieDetail characterForMovieOrSerieDetail = _query.GetCharacterForMovieOrSerieDetail(id);
            if (characterForMovieOrSerieDetail == null)
            {
                NullReferenceException exception = new NullReferenceException("Personaje con id " + id + " no encontrado");
                throw exception;
            }
            else
            {
                return characterForMovieOrSerieDetail;
            }
        }
*/
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

        public List<ResponseGetAllCharacterDto> GetCharactersByAge(string age)
        {
            return _query.GetCharactersByAge(age);
        }

        public List<ResponseGetAllCharacterDto> GetCharactersByIdMovie(string idMovie)
        {
            return _query.GetCharactersByIdMovie(idMovie);
        }

        public List<ResponseGetAllCharacterDto> GetCharactersByName(string name)
        {
            return _query.GetCharactersByName(name);
        }

        public bool UpdateCharacter(int id, CreateCharacterRequestDto characterRequestDto)
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
