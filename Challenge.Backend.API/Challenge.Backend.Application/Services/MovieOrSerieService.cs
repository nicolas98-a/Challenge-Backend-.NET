using Challenge.Backend.Domain.DTOs;
using Challenge.Backend.Domain.Entities;
using Challenge.Backend.Domain.ICommands;
using Challenge.Backend.Domain.IQueries;
using System;
using System.Collections.Generic;

namespace Challenge.Backend.Application.Services
{
    public interface IMovieOrSerieService
    {
        ResponseMovieOrSerieForCharacterDetail GetMovieOrSerieById(int id);
        List<ResponseGetAllMovieOrSerieDto> GetMoviesOrSeries();
        List<ResponseGetAllMovieOrSerieDto> GetMoviesOrSeriesByName( string name);
        List<ResponseGetAllMovieOrSerieDto> GetMoviesOrSeriesByGenreId(string idGenre);
        List<ResponseGetAllMovieOrSerieDto> GetMoviesOrSeriesByOrder(string order);
        ResponseMovieOrSerieDetailDto GetMovieOrSerieDetail(int id);
        GenericCreatedResponseDto CreateMovieOrSerie(CreateMovieRequestDto movieRequestDto);
        bool UpdateMovie(int id, UpdateMovieRequestDto movieRequestDto);
        bool DeleteMovieOrSerie(int id);

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
            List<Character> characters = GetCharactersFromRequest(movieRequestDto.Characters);

            var entity = new MovieOrSerie
            {
                Image = movieRequestDto.Image,
                Title = movieRequestDto.Title,
                CreationDate = movieRequestDto.CreationDate,
                Rating = movieRequestDto.Rating,
                GenreId = movieRequestDto.GenreId,
                CharactersNavigator = characters
            };

            _repository.Add(entity);

            return new GenericCreatedResponseDto { Entity = "MovieOrSerie", Id = entity.MovieOrSerieId.ToString() };
        }

        private List<Character> GetCharactersFromRequest(IList<int> ids)
        {
            List<Character> charactersAux = new List<Character>();

            foreach (var item in ids)
            {
                Character character = _repository.Exists<Character>(item);
                if (character != null)
                {
                    charactersAux.Add(character);
                }
            }
            return charactersAux;
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

        public bool DeleteMovieOrSerie(int id)
        {
            MovieOrSerie movie = _repository.Exists<MovieOrSerie>(id);
            if (movie == null)
            {
                return false;
            }
            else
            {
                _repository.Delete<MovieOrSerie>(movie);
                return true;
            }
        }

        public bool UpdateMovie(int id, UpdateMovieRequestDto movieRequestDto)
        {
            MovieOrSerie movie = _repository.Exists<MovieOrSerie>(id);
            if (movie == null)
            {
                return false;
            }
            else
            {
                movie.Image = movieRequestDto.Image;
                movie.Title = movieRequestDto.Title;
                movie.CreationDate = movieRequestDto.CreationDate;
                movie.Rating = movieRequestDto.Rating;
                movie.GenreId = movieRequestDto.GenreId;

                _repository.Update<MovieOrSerie>(movie);
                return true;
            }

        }

        public List<ResponseGetAllMovieOrSerieDto> GetMoviesOrSeriesByName(string name)
        {
            return _query.GetMoviesOrSeriesByName(name);
        }

        public List<ResponseGetAllMovieOrSerieDto> GetMoviesOrSeriesByGenreId(string idGenre)
        {
            return _query.GetMoviesOrSeriesByGenreId(idGenre);
        }

        public List<ResponseGetAllMovieOrSerieDto> GetMoviesOrSeriesByOrder(string order)
        {
            return _query.GetMoviesOrSeriesByOrder(order);
        }
    }
}
