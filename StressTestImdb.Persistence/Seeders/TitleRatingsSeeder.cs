using StressTestImdb.Domain.Entities;
using StressTestImdb.Persistence.Database;

namespace StressTestImdb.Persistence.Seeders;
public class TitleRatingsSeeder
{
    public static void Seed(ImdbContext context)
    {
        if (context.TitleRatings.Any()) return;
        var titleRatings = File.ReadAllLines("title.ratings.tsv");
        var titleRatingsList = new List<TitleRatings>();

        foreach (var titleRt in titleRatings.Skip(1))
        {
            var titleRtData = titleRt.Split('\t');

            var titleRtObj = new TitleRatings
            {
                tconst = titleRtData[0],
                averageRating = double.Parse(titleRtData[1]),
                numVotes = int.Parse(titleRtData[2])
            };

            titleRatingsList.Add(titleRtObj);
        }

        context.TitleRatings.AddRange(titleRatingsList);
        context.SaveChanges();
    }
}
