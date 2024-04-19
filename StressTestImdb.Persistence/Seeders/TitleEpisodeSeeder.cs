using StressTestImdb.Domain.Entities;
using StressTestImdb.Persistence.Database;

namespace StressTestImdb.Persistence.Seeders;
public class TitleEpisodeSeeder
{
    public static void Seed(ImdbContext context)
    {
        if (context.TitleEpisode.Any()) return;

        using StreamReader reader = new("title.episode.tsv");

        reader.ReadLine();

        string line;
        int count = 0;

        while ((line = reader.ReadLine()) != null)
        {
            context.TitleEpisode.Add(TitleEpisode.FromCsv(line));

            // Save changes after a certain number of entries to avoid excessive database calls
            if (context.TitleEpisode.Local.Count % 10000 == 0)
            {
                count += context.TitleEpisode.Local.Count;
                Console.WriteLine($"Saving {context.TitleEpisode.Local.Count} entries to the database...");
                Console.WriteLine($"Total entries saved: {count}");
                context.SaveChanges();
                // Clear the context to avoid tracking too many entities
                context.TitleEpisode.Local.Clear();
            }
        }

        // Save any remaining changes
        context.SaveChanges();
        
    }
}
