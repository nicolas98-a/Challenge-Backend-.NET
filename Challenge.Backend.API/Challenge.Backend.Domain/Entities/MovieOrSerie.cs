using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Backend.Domain.Entities
{
    public class MovieOrSerie
    {
        public int MovieOrSerieId { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public DateTime CreationDate { get; set; }
        public int Rating { get; set; }
        public int GenreId { get; set; }
        public Genre GenreNavigator { get; set; }
        public IList<Character> CharactersNavigator { get; set; }
    }
}
