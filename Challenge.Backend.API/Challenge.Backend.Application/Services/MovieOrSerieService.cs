using Challenge.Backend.Domain.DTOs;
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
    }
    public class MovieOrSerieService : IMovieOrSerieService
    {
        private readonly IMovieOrSerieQuery _query;

        public MovieOrSerieService( IMovieOrSerieQuery query)
        {
            _query = query;
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
    }
}
