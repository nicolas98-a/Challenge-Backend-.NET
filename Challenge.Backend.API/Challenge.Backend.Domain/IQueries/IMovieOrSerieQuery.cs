using Challenge.Backend.Domain.DTOs;
using System.Collections.Generic;

namespace Challenge.Backend.Domain.IQueries
{
    public interface IMovieOrSerieQuery
    {
        ResponseMovieOrSerieForCharacterDetail GetMoviesOrSeriesById(int id);
        List<ResponseGetAllMovieOrSerieDto> GetAllMovieOrSeries();
        List<ResponseGetAllMovieOrSerieDto> GetMoviesOrSeriesByName(string name);
        List<ResponseGetAllMovieOrSerieDto> GetMoviesOrSeriesByGenreId(string idGenre);
        List<ResponseGetAllMovieOrSerieDto> GetMoviesOrSeriesByOrder(string order);
        ResponseMovieOrSerieDetailDto GetMovieOrSerieDetail(int id);
    }
}
