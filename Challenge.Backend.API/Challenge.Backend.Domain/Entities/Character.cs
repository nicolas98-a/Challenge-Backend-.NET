using System.Collections.Generic;

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
