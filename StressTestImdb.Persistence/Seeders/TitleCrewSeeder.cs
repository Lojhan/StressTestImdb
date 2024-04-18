using StressTestImdb.Domain.Entities;
using StressTestImdb.Persistence.Database;

namespace StressTestImdb.Persistence.Seeders;
public class TitleCrewSeeder
{
    public static void Seed(ImdbContext context)
    {
        if (context.TitleCrew.Any()) return;
        var titleCrew = File.ReadAllLines("title.crew.tsv");

        foreach (var tc in titleCrew.Skip(1))
            context.TitleCrew.Add(TitleCrew.FromCsv(tc));


        context.SaveChanges();
    }
}
