using System;

namespace Challenge.Backend.Domain.DTOs
{
    public class MovieOrSerieDto
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public int Rating { get; set; }
        public int GenreId { get; set; }
    }
}
