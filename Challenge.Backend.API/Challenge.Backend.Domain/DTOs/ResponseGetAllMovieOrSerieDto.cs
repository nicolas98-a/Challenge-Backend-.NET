using System;

namespace Challenge.Backend.Domain.DTOs
{
    public class ResponseGetAllMovieOrSerieDto
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
