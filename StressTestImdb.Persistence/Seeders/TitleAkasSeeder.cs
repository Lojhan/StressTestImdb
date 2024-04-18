using StressTestImdb.Domain.Entities;
using StressTestImdb.Persistence.Database;

namespace StressTestImdb.Persistence.Seeders;

public class TitleAkasSeeder
{
    public static void Seed(ImdbContext context)
    {
        if (context.TitleAkas.Any()) return;
        var titleAkas = File.ReadAllLines("title.akas.tsv");

        foreach (var titleAka in titleAkas.Skip(1))
            context.TitleAkas.Add(TitleAkas.FromCsv(titleAka));
        
        context.SaveChanges();
    }
}
