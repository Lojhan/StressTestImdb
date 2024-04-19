using StressTestImdb.Domain.Entities;
using StressTestImdb.Persistence.Database;

namespace StressTestImdb.Persistence.Seeders;
public class TitleCrewSeeder
{
    public static void Seed(ImdbContext context)
    {
        if (context.TitleCrew.Any()) return;
        
        using StreamReader reader = new("title.crew.tsv");

        reader.ReadLine();

        string line;
        int count = 0;

        while ((line = reader.ReadLine()) != null)
        {
            context.TitleCrew.Add(TitleCrew.FromCsv(line));

            // Save changes after a certain number of entries to avoid excessive database calls
            if (context.TitleCrew.Local.Count % 10000 == 0)
            {
                count += context.TitleCrew.Local.Count;
                Console.WriteLine($"Saving {context.TitleCrew.Local.Count} entries to the database...");
                Console.WriteLine($"Total entries saved: {count}");
                context.SaveChanges();
                // Clear the context to avoid tracking too many entities
                context.TitleCrew.Local.Clear();
            }
        }

        // Save any remaining changes
        context.SaveChanges();
    }
}
