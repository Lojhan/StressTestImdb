using StressTestImdb.Domain.Entities;
using StressTestImdb.Persistence.Database;

namespace StressTestImdb.Persistence.Seeders;

public class TitleAkasSeeder
{
    public static void Seed(ImdbContext context)
    {
        if (context.TitleAkas.Any()) return;

        using StreamReader reader = new("title.akas.tsv");
        reader.ReadLine();

        string line;
        int count = 0;

        while ((line = reader.ReadLine()) != null)
        {
            context.TitleAkas.Add(TitleAkas.FromCsv(line));

            // Save changes after a certain number of entries to avoid excessive database calls
            if (context.TitleAkas.Local.Count % 10000 == 0)
            {
                count += context.TitleAkas.Local.Count;
                Console.WriteLine($"Saving {context.TitleAkas.Local.Count} entries to the database...");
                Console.WriteLine($"Total entries saved: {count}");
                context.SaveChanges();
                // Clear the context to avoid tracking too many entities
                context.TitleAkas.Local.Clear();
            }
        }

        // Save any remaining changes
        context.SaveChanges();
    }
}
