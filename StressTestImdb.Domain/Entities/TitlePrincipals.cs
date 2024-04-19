using System.Text.Json;

namespace StressTestImdb.Domain.Entities;

public class TitlePrincipals(
    string tconst,
    int ordering,
    string nconst,
    string category,
    string job,
    string[] characters
)
{
    public string Tconst { get; set; } = tconst;
    public int Ordering { get; set; } = ordering;
    public string Nconst { get; set; } = nconst;
    public string Category { get; set; } = category;
    public string Job { get; set; } = job;
    public string[] Characters { get; set; } = characters;
    public TitleBasics TitleBasics { get; set; } = null!;

    public static TitlePrincipals FromCsv(string csvLine)
    {
        var values = csvLine.Split('\t');
        var titlePrincipals = new TitlePrincipals(
            values[0],
            values[1] == @"\N" ? 0 : int.Parse(values[1]),
            values[2],
            values[3],
            values[4],
            values[5] == @"\N" ? [] : JsonSerializer.Deserialize<string[]>(values[5])!
        );

        return titlePrincipals;
    }
}
