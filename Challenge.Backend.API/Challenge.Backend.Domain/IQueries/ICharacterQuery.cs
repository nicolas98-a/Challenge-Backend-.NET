using Challenge.Backend.Domain.DTOs;
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
    }
}
