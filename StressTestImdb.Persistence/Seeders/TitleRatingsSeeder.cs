using StressTestImdb.Domain.Entities;
using StressTestImdb.Persistence.Database;

namespace StressTestImdb.Persistence.Seeders;
public class TitleRatingsSeeder
{
    public static void Seed(ImdbContext context)
    {
        if (context.TitleRatings.Any()) return;

        using StreamReader reader = new("title.ratings.tsv");

        reader.ReadLine();

        string line;
        int count = 0;

        while ((line = reader.ReadLine()) != null)
        {
            context.TitleRatings.Add(TitleRating.FromCsv(line));

            // Save changes after a certain number of entries to avoid excessive database calls
            if (context.TitleRatings.Local.Count % 10000 == 0)
            {
                count += context.TitleRatings.Local.Count;
                Console.WriteLine($"Saving {context.TitleRatings.Local.Count} entries to the database...");
                Console.WriteLine($"Total entries saved: {count}");
                context.SaveChanges();
                // Clear the context to avoid tracking too many entities
                context.TitleRatings.Local.Clear();
            }
        }

        // Save any remaining changes
        context.SaveChanges();
    }
}
