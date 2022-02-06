using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Backend.Domain.Entities
{
    public class Character
    {
        public int CharacterId { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public string History { get; set; }
        public IList<MovieOrSerie> MovieOrSeriesNavigator { get; set; }
    }
}
