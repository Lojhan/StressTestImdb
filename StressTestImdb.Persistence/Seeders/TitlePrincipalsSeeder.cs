using StressTestImdb.Domain.Entities;
using StressTestImdb.Persistence.Database;

namespace StressTestImdb.Persistence.Seeders;
public class TitlePrincipalsSeeder
{
    public static void Seed(ImdbContext context)
    {
        if (context.TitlePrincipals.Any()) return;
        
        using StreamReader reader = new("title.principals.tsv");

        reader.ReadLine();

        string line;
        int count = 0;

        while ((line = reader.ReadLine()) != null)
        {
            context.TitlePrincipals.Add(TitlePrincipals.FromCsv(line));

            // Save changes after a certain number of entries to avoid excessive database calls
            if (context.TitlePrincipals.Local.Count % 10000 == 0)
            {
                count += context.TitlePrincipals.Local.Count;
                Console.WriteLine($"Saving {context.TitlePrincipals.Local.Count} entries to the database...");
                Console.WriteLine($"Total entries saved: {count}");
                context.SaveChanges();
                // Clear the context to avoid tracking too many entities
                context.TitlePrincipals.Local.Clear();
            }
        }

        // Save any remaining changes
        context.SaveChanges();
    }
}
