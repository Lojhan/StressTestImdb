namespace StressTestImdb.Domain.Entities;

public class NameBasics
{
    public string nconst { get; set; }
    public string primaryName { get; set; }
    public int birthYear { get; set; }
    public int deathYear { get; set; }
    public string[] primaryProfession { get; set; }
    public string[] knownForTitles { get; set; }
}