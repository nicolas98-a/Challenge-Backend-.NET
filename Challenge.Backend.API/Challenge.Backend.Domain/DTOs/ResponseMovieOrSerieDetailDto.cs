using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Backend.Domain.DTOs
{
    public class ResponseMovieOrSerieDetailDto
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public int Rating { get; set; }
        public string Genre { get; set; }
        public List<ResponseCharacterForMovieOrSerieDetail> Characters { get; set; }
    }

    public class ResponseGetMovieDetailGenre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
    }

    public class ResponseCharacterForMovieOrSerieDetail
    {
        public int CharacterId { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string History { get; set; }
    }
    
}
