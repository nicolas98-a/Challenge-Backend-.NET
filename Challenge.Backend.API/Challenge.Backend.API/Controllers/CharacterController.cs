using Challenge.Backend.Application.Services;
using Challenge.Backend.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Backend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _service;
        public CharacterController(ICharacterService service)
        {
            _service = service;
        }

        [HttpGet("/characters")]
        [ProducesResponseType(typeof(List<ResponseGetAllCharacterDto>), StatusCodes.Status200OK)]
        public IActionResult GetCharacters()
        {
            try
            {
                return new JsonResult(_service.GetCharacters()) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(GenericCreatedResponseDto), StatusCodes.Status201Created)]
        public IActionResult Post(CharacterRequestDto character)
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

        [HttpPut("{Id}")]
        public IActionResult PutCharacter(int id, CharacterRequestDto character)
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

        [HttpDelete("{Id}")]
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
    }
}
