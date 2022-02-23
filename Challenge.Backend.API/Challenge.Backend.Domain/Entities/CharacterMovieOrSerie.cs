namespace Challenge.Backend.Domain.Entities
{
    public class CharacterMovieOrSerie
    {
        public int CharacterMovieOrSerieId { get; set; }
        public int CharacterId { get; set; }
        public Character CharacterNavigator { get; set; }
        public int MovieOrSerieId { get; set; }
        public MovieOrSerie MovieOrSerieNavigator { get; set; }
    }
}
