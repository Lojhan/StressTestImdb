namespace StressTestImdb.Domain.Entities;

public class TitleEpisode
{
    public string tconst { get; set; }
    public string parentTconst { get; set; }
    public int seasonNumber { get; set; }
    public int episodeNumber { get; set; }
}
