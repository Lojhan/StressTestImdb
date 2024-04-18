namespace StressTestImdb.Domain.Entities;

public class TitleBasics
{
    public string tconst { get; set; }
    public string titleType { get; set; }
    public string primaryTitle { get; set; }
    public string originalTitle { get; set; }
    public bool isAdult { get; set; }
    public int startYear { get; set; }
    public int endYear { get; set; }
    public int runtimeMinutes { get; set; }
    public string[] genres { get; set; }
}
