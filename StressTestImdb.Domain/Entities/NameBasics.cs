using System.Text.Json;

namespace StressTestImdb.Domain.Entities;

public class NameBasics
(
    string nconst,
    string primaryName,
    int birthYear,
    int deathYear,
    string[] primaryProfession,
    string[] knownForTitles
)
{
    public string Nconst { get; set; } = nconst;
    public string PrimaryName { get; set; } = primaryName;
    public int BirthYear { get; set; } = birthYear;
    public int DeathYear { get; set; } = deathYear;
    public string[] PrimaryProfession { get; set; } = primaryProfession;
    public string[] KnownForTitles { get; set; } = knownForTitles;

    public static NameBasics FromCsv(string csvLine)
    {
        var values = csvLine.Split('\t');
        var nameBasics = new NameBasics(
            values[0],
            values[1],
            values[2] == @"\N" ? 0 : int.Parse(values[2]),
            values[3] == @"\N" ? 0 : int.Parse(values[3]),
            JsonSerializer.Deserialize<string[]>(values[4])!,
            JsonSerializer.Deserialize<string[]>(values[5])!
        );

        return nameBasics;
    }
}