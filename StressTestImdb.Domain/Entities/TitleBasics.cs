using System.Text.Json;

namespace StressTestImdb.Domain.Entities;

public class TitleBasics(
    string tconst,
    string titleType,
    string primaryTitle,
    string originalTitle,
    bool isAdult,
    int startYear,
    int endYear,
    int runtimeMinutes,
    string[] genres
)
{
    public string Tconst { get; set; } = tconst;
    public string TitleType { get; set; } = titleType;
    public string PrimaryTitle { get; set; } = primaryTitle;
    public string OriginalTitle { get; set; } = originalTitle;
    public bool IsAdult { get; set; } = isAdult;
    public int StartYear { get; set; } = startYear;
    public int EndYear { get; set; } = endYear;
    public int RuntimeMinutes { get; set; } = runtimeMinutes;
    public string[] Genres { get; set; } = genres;

    public TitleAkas TitleAkas { get; set; } = null!;
    public TitleCrew TitleCrew { get; set; } = null!;
    public TitleEpisode[] TitleEpisodes { get; set; } = [];
    public TitlePrincipals[] TitlePrincipals { get; set; } = [];
    public TitleRating TitleRating { get; set; } = null!;

    public static TitleBasics FromCsv(string csvLine)
    {
        var values = csvLine.Split('\t');
        var titleBasics = new TitleBasics(
            values[0],
            values[1],
            values[2],
            values[3],
            values[4] == "1",
            values[5] == @"\N" ? 0 : int.Parse(values[5]),
            values[6] == @"\N" ? 0 : int.Parse(values[6]),
            values[7] == @"\N" ? 0 : int.Parse(values[7]),
            values[8] == @"\N" ? [] : values[8].Split(',')
        );

        return titleBasics;
    }
}
