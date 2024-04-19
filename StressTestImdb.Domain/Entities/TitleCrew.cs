using System.Text.Json;

namespace StressTestImdb.Domain.Entities;

public class TitleCrew(
    string tconst,
    string[] directors,
    string[] writers
)
{
    public string Tconst { get; set; } = tconst;
    public string[] Directors { get; set; } = directors;
    public string[] Writers { get; set; } = writers;

    public TitleBasics TitleBasics { get; set; } = null!;

    public static TitleCrew FromCsv(string csvLine)
    {
        var values = csvLine.Split('\t');
        var titleCrew = new TitleCrew(
            values[0],
            values[1] == @"\N" ? [] : values[1].Split(','),
            values[2] == @"\N" ? [] : values[2].Split(',')
        );

        return titleCrew;
    }
}
