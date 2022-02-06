using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Backend.Domain.Entities
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public ICollection<MovieOrSerie> MovieOrSeriesNavigator { get; set; }
    }
}
