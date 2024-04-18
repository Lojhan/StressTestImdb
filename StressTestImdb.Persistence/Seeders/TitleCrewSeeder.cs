using StressTestImdb.Domain.Entities;
using StressTestImdb.Persistence.Database;

namespace StressTestImdb.Persistence.Seeders;
public class TitleCrewSeeder
{
    public static void Seed(ImdbContext context)
    {
        if (context.TitleCrew.Any()) return;
        var titleCrew = File.ReadAllLines("title.crew.tsv");
        var titleCrewList = new List<TitleCrew>();

        foreach (var titleCr in titleCrew.Skip(1))
        {
            var titleCrData = titleCr.Split('\t');

            var titleCrObj = new TitleCrew
            {
                tconst = titleCrData[0],
                directors = titleCrData[1].Split(','),
                writers = titleCrData[2].Split(',')
            };

            titleCrewList.Add(titleCrObj);
        }

        context.TitleCrew.AddRange(titleCrewList);
        context.SaveChanges();
    }
}
