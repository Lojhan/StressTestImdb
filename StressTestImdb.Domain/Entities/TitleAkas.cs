namespace StressTestImdb.Domain.Entities;

public class TitleAkas(
    string titleId,
    int ordering,
    string title,
    string region,
    string language,
    string[] types,
    string[] attributes,
    bool isOriginalTitle
)
{
    public string TitleId { get; set; } = titleId;
    public int Ordering { get; set; } = ordering;
    public string Title { get; set; } = title;
    public string Region { get; set; } = region;
    public string Language { get; set; } = language;
    public string[] Types { get; set; } = types;
    public string[] Attributes { get; set; } = attributes;
    public bool IsOriginalTitle { get; set; } = isOriginalTitle;

    public TitleBasics TitleBasics { get; set; } = null!;
    public TitleCrew TitleCrew { get; set; } = null!;
    public TitleEpisode[] TitleEpisodes { get; set; } = [];
    public TitlePrincipals[] TitlePrincipals { get; set; } = [];
    public TitleRating TitleRating { get; set; } = null!;
    
    public static TitleAkas FromCsv(string csvLine)
    {
        var values = csvLine.Split('\t');
        var titleAkas = new TitleAkas(
            values[0],
            int.Parse(values[1]),
            values[2],
            values[3],
            values[4],
            values[5].Split(','),
            values[6].Split(','),
            values[7] == "1"
        );

        return titleAkas;
    }
}
