using StressTestImdb.Domain.Entities;
using StressTestImdb.Persistence.Database;

namespace StressTestImdb.Persistence.Seeders;
public class TitleRatingsSeeder
{
    public static void Seed(ImdbContext context)
    {
        if (context.TitleRatings.Any()) return;
        var titleRatings = File.ReadAllLines("title.ratings.tsv");
        
        foreach (var titleRating in titleRatings.Skip(1))
            context.TitleRatings.Add(TitleRating.FromCsv(titleRating));
            
        context.SaveChanges();
    }
}
