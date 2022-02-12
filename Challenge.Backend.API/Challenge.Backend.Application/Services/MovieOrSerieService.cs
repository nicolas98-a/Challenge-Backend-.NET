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
    public interface IMovieOrSerieService
    {
        ResponseMovieOrSerieForCharacterDetail GetMovieOrSerieById(int id);
        List<ResponseGetAllMovieOrSerieDto> GetMoviesOrSeries();
        ResponseMovieOrSerieDetailDto GetMovieOrSerieDetail(int id);
        GenericCreatedResponseDto CreateMovieOrSerie(CreateMovieRequestDto movieRequestDto);
    }
    public class MovieOrSerieService : IMovieOrSerieService
    {
        private readonly IMovieOrSerieQuery _query;
        private readonly IGenericsRepository _repository;

        public MovieOrSerieService( IMovieOrSerieQuery query, IGenericsRepository repository)
        {
            _query = query;
            _repository = repository;
        }

        public GenericCreatedResponseDto CreateMovieOrSerie(CreateMovieRequestDto movieRequestDto)
        {
            var entity = new MovieOrSerie
            {
                Image = movieRequestDto.Image,
                Title = movieRequestDto.Title,
                CreationDate = movieRequestDto.CreationDate,
                Rating = movieRequestDto.Rating,
                GenreId = movieRequestDto.GenreId
            };

            _repository.Add(entity);
            foreach (var item in movieRequestDto.Characters)
            {
                RegisterChracterMovie(item, entity.MovieOrSerieId);
            }

            return new GenericCreatedResponseDto { Entity = "MovieOrSerie", Id = entity.MovieOrSerieId.ToString() };
        }

        private void RegisterChracterMovie(int idCharacter, int idMovie)
        {
            var entity = new CharacterMovieOrSerie { CharacterId = idCharacter, MovieOrSerieId = idMovie };
            _repository.Add(entity);
        }

        public ResponseMovieOrSerieForCharacterDetail GetMovieOrSerieById(int id)
        {
            ResponseMovieOrSerieForCharacterDetail movieOrSerieForCharacterDetail = _query.GetMoviesOrSeriesById(id);
            if (movieOrSerieForCharacterDetail == null)
            {
                NullReferenceException exception = new NullReferenceException("Pelicula o serie con id " + id + "no encontrada");
                throw exception;
            }
            else
            {
                return movieOrSerieForCharacterDetail;
            }
        }

        public ResponseMovieOrSerieDetailDto GetMovieOrSerieDetail(int id)
        {
            ResponseMovieOrSerieDetailDto movieOrSerieDetail = _query.GetMovieOrSerieDetail(id);
            if (movieOrSerieDetail == null)
            {
                NullReferenceException exception = new NullReferenceException("Pelicula o serie con id " + id + "no encontrada");
                throw exception;
            }
            else
            {
                return movieOrSerieDetail;
            }
        }

        public List<ResponseGetAllMovieOrSerieDto> GetMoviesOrSeries()
        {
            return _query.GetAllMovieOrSeries();
        }
    }
}
