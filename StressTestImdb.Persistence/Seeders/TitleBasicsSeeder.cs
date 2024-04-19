using StressTestImdb.Domain.Entities;
using StressTestImdb.Persistence.Database;

namespace StressTestImdb.Persistence.Seeders;
public class TitleBasicsSeeder
{
    public static void Seed(ImdbContext context)
    {
        if (context.TitleBasics.Any()) return;

        using StreamReader reader = new("title.basics.tsv");
        reader.ReadLine();

        string line;
        int count = 0;
        while ((line = reader.ReadLine()) != null)
        {
            context.TitleBasics.Add(TitleBasics.FromCsv(line));

            // Save changes after a certain number of entries to avoid excessive database calls
            if (context.TitleBasics.Local.Count % 10000 == 0)
            {
                count += context.TitleBasics.Local.Count;
                Console.WriteLine($"Saving {context.TitleBasics.Local.Count} entries to the database...");
                Console.WriteLine($"Total entries saved: {count}");
                context.SaveChanges();
                // Clear the context to avoid tracking too many entities
                context.TitleBasics.Local.Clear();
            }
        }

        // Save any remaining changes
        context.SaveChanges();
    }
}
