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
        public IActionResult GetMoviesOrSeries()
        {
            try
            {
                return new JsonResult(_service.GetMoviesOrSeries()) { StatusCode = 200 };
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
    }
}
