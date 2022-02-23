using Challenge.Backend.Application.Services;
using Challenge.Backend.Domain.DTOs;
using Challenge.Backend.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Backend.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _service;
        public CharacterController(ICharacterService service)
        {
            _service = service;
        }

        /// <summary>
        /// Devuelve una lista de personajes
        /// </summary>
        /// <returns>Retorna la imagen y el nombre del personaje</returns>
        [HttpGet("/characters")]
        [ProducesResponseType(typeof(List<ResponseGetAllCharacterDto>), StatusCodes.Status200OK)]
        public IActionResult GetCharacters([FromQuery] string name, [FromQuery] string age, [FromQuery] string idMovie)
        {
            try
            {
                if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(age) && string.IsNullOrEmpty(idMovie))
                {
                    return new JsonResult(_service.GetCharacters()) { StatusCode = 200 };
                }
                else
                {
                    if (string.IsNullOrEmpty(age) && string.IsNullOrEmpty(idMovie))
                    {
                        return new JsonResult(_service.GetCharactersByName(name)) { StatusCode = 200 };
                    }
                    else if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(age))
                    {
                        return new JsonResult(_service.GetCharactersByIdMovie(idMovie)) { StatusCode = 200 };
                    }
                    else
                    {
                        return new JsonResult(_service.GetCharactersByAge(age)) { StatusCode = 200 };
                    }
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        /// <summary>
        /// Agrega un personaje
        /// </summary>
        /// <param name="character"></param>
        /// <returns>Retorna el id del personaje y la entidad a la que pertenece</returns>
        [HttpPost]
        [ProducesResponseType(typeof(GenericCreatedResponseDto), StatusCodes.Status201Created)]
        public IActionResult Post(CreateCharacterRequestDto character)
        {
            try
            {
                return new JsonResult(_service.CreateCharacter(character)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return new JsonResult(BadRequest(e.Message));
            }
        }

        /// <summary>
        /// Actualiza los datos de un personaje
        /// </summary>
        /// <param name="id"></param>
        /// <param name="character"></param>
        /// <returns>No retorna contenido</returns>
        [HttpPut("{id}")]
        public IActionResult PutCharacter(int id, CreateCharacterRequestDto character)
        {
            try
            {
                if (_service.UpdateCharacter(id, character))
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Borra un personaje
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No retorna contenido</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteCharacter(int id)
        {
            try
            {
                if (_service.DeleteCharacter(id))
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Devuelve el detalle de un personaje segun su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna los datos de un personaje</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseCharacterDetailDto), StatusCodes.Status200OK)]
        public IActionResult GetCharacterDetails(int id)
        {
            try
            {
                return new JsonResult(_service.GetCharacterDetail(id)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return new JsonResult(BadRequest(e.Message)) { StatusCode = 400 }; 
            }
        }
    }
}
