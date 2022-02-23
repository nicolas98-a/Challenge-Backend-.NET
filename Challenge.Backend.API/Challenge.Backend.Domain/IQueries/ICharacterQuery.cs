using Challenge.Backend.Domain.DTOs;
using System.Collections.Generic;

namespace Challenge.Backend.Domain.IQueries
{
    public  interface ICharacterQuery
    {
        List<ResponseGetAllCharacterDto> GetAllCharacters();
        ResponseCharacterDetailDto GetCharacterDetail(int id);
        List<ResponseGetAllCharacterDto> GetCharactersByName(string name);
        List<ResponseGetAllCharacterDto> GetCharactersByAge(string age);
        List<ResponseGetAllCharacterDto> GetCharactersByIdMovie(string idMovie);

    }
}
