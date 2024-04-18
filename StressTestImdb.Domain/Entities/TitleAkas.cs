namespace StressTestImdb.Domain.Entities;

public class TitleAkas
{
    public string titleId { get; set; }
    public int ordering { get; set; }
    public string title { get; set; }
    public string region { get; set; }
    public string language { get; set; }
    public string[] types { get; set; }
    public string[] attributes { get; set; }
    public bool isOriginalTitle { get; set; }
}
