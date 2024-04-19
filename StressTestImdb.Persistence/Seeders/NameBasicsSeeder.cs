using StressTestImdb.Domain.Entities;
using StressTestImdb.Persistence.Database;

namespace StressTestImdb.Persistence.Seeders;
public class NameBasicsSeeder
{
    public static void Seed(ImdbContext context)
    {
        if (context.NameBasics.Any()) return;
        
        using StreamReader reader = new("name.basics.tsv");
        reader.ReadLine();

        string line;
        int count = 0;

        while ((line = reader.ReadLine()) != null)
        {
            context.NameBasics.Add(NameBasics.FromCsv(line));

            // Save changes after a certain number of entries to avoid excessive database calls
            if (context.NameBasics.Local.Count % 10000 == 0)
            {
                count += context.NameBasics.Local.Count;
                Console.WriteLine($"Saving {context.NameBasics.Local.Count} entries to the database...");
                Console.WriteLine($"Total entries saved: {count}");
                context.SaveChanges();
                // Clear the context to avoid tracking too many entities
                context.NameBasics.Local.Clear();
            }
        }

        // Save any remaining changes
        context.SaveChanges();
    }
}
