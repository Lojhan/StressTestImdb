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
            int.Parse(values[2]),
            int.Parse(values[3]),
            values[4].Split(','),
            values[5].Split(',')
        );

        return nameBasics;
    }
}