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

    public static TitleBasics FromCsv(string csvLine)
    {
        var values = csvLine.Split('\t');
        var titleBasics = new TitleBasics(
            values[0],
            values[1],
            values[2],
            values[3],
            values[4] == "1",
            int.Parse(values[5]),
            int.Parse(values[6]),
            int.Parse(values[7]),
            values[8].Split(',')
        );

        return titleBasics;
    }
}
