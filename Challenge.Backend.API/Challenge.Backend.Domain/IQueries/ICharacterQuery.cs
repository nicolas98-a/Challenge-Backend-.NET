﻿using Challenge.Backend.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
