using System;
using System.Collections.Generic;

namespace Challenge.Backend.Domain.DTOs
{
    public class CreateMovieRequestDto
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public int Rating { get; set; }
        public int GenreId { get; set; }
        public IList<int> Characters { get; set; }
    }
}
