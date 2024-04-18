namespace StressTestImdb.Domain.Entities;

public class TitleEpisode(
    string tconst,
    string parentTconst,
    int seasonNumber,
    int episodeNumber
)
{
    public string Tconst { get; set; } = tconst;
    public string ParentTconst { get; set; } = parentTconst;
    public int SeasonNumber { get; set; } = seasonNumber;
    public int EpisodeNumber { get; set; } = episodeNumber;
    public TitleAkas TitleAkas { get; set; } = null!;

    public static TitleEpisode FromCsv(string csvLine)
    {
        var values = csvLine.Split('\t');
        var titleEpisode = new TitleEpisode(
            values[0],
            values[1],
            int.Parse(values[2]),
            int.Parse(values[3])
        );

        return titleEpisode;
    }
}
