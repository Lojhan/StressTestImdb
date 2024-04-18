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

    public static TitleCrew FromCsv(string csvLine)
    {
        var values = csvLine.Split('\t');
        var titleCrew = new TitleCrew(
            values[0],
            values[1].Split(','),
            JsonSerializer.Deserialize<string[]>(values[2])!
        );

        return titleCrew;
    }
}
