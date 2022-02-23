using Challenge.Backend.Application.Services;
using Challenge.Backend.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Challenge.Backend.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MovieOrSerieController : ControllerBase
    {
        private readonly IMovieOrSerieService _service;
        public MovieOrSerieController(IMovieOrSerieService service)
        {
            _service = service;
        }

        /// <summary>
        /// Devuelve una lista de peliculas o series
        /// </summary>
        /// <returns>Retorna la imagen, el titulo y la fecha de creacion de la pelicula o serie</returns>
        [HttpGet("/movies")]
        [ProducesResponseType(typeof(List<ResponseGetAllMovieOrSerieDto>), StatusCodes.Status200OK)]
        public IActionResult GetMoviesOrSeries([FromQuery] string name, [FromQuery] string genre, [FromQuery] string order)
        {
            try
            {
                if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(genre) && string.IsNullOrEmpty(order))
                {
                    return new JsonResult(_service.GetMoviesOrSeries()) { StatusCode = 200 };
                }
                else
                {
                    if (string.IsNullOrEmpty(genre) && string.IsNullOrEmpty(order))
                    {
                        return new JsonResult(_service.GetMoviesOrSeriesByName(name)) { StatusCode = 200 };
                    }
                    else if (string.IsNullOrEmpty(name) && string.IsNullOrEmpty(genre))
                    {
                        return new JsonResult(_service.GetMoviesOrSeriesByOrder(order)) { StatusCode = 200 };
                    }
                    else
                    {
                        return new JsonResult(_service.GetMoviesOrSeriesByGenreId(genre)) { StatusCode = 200 };
                    }
                }
                
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Devuelve el detalle de una pelicula o serie segun su id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna los datos de una pelicula o serie</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ResponseMovieOrSerieDetailDto), StatusCodes.Status200OK)]
        public IActionResult GetMovieDetails(int id)
        {
            try
            {
                return new JsonResult(_service.GetMovieOrSerieDetail(id)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return new JsonResult(BadRequest(e.Message)) { StatusCode = 400 };
            }
        }

        /// <summary>
        /// Agrega una pelicula o serie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns>Retorna el id de la pelicula y la entidad a la que pertenece</returns>
        [HttpPost]
        [ProducesResponseType(typeof(GenericCreatedResponseDto), StatusCodes.Status201Created)]
        public IActionResult Post(CreateMovieRequestDto movie)
        {
            try
            {
                return new JsonResult(_service.CreateMovieOrSerie(movie)) { StatusCode = 201 };
            }
            catch (Exception e)
            {
                return new JsonResult(BadRequest(e.Message));
            }
        }

        /// <summary>
        /// Actualiza los datos de una pelicula o serie
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movie"></param>
        /// <returns>No retorna contenido</returns>
        [HttpPut("{id}")]
        public IActionResult PutMovieOrSerie(int id, UpdateMovieRequestDto movie)
        {
            try
            {
                if (_service.UpdateMovie(id, movie))
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
        /// Borra una pelicula o serie
        /// </summary>
        /// <param name="id"></param>
        /// <returns>No retorna contenido</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteMovie(int id)
        {
            try
            {
                if (_service.DeleteMovieOrSerie(id))
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
