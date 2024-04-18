namespace StressTestImdb.Domain.Entities;

public class TitleRating(
    string tconst,
    double averageRating,
    int numVotes
)
{
    public string Tconst { get; set; } = tconst;
    public double AverageRating { get; set; } = averageRating;
    public int NumVotes { get; set; } = numVotes;
    public TitleAkas TitleAkas { get; set; } = null!;

    public static TitleRating FromCsv(string csvLine)
    {
        var values = csvLine.Split('\t');
        var titleRatings = new TitleRating(
            values[0],
            double.Parse(values[1]),
            int.Parse(values[2])
        );

        return titleRatings;
    }
}
