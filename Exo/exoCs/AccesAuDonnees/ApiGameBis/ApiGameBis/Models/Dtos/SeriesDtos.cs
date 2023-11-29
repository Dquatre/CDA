using ApiGameBis.Models.Data;

namespace ApiGameBis.Models.Dtos
{
    public class SeriesDtoWithListGame
    {
        public string SerieName { get; set; } = null!;

        public virtual ICollection<GamesDto> ListGames { get; set; } = new List<GamesDto>();
    }

    public class SeriesDto
    {
        public string SerieName { get; set; } = null!;
    }
}
