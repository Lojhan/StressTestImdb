using StressTestImdb.Domain.Entities;
using StressTestImdb.Persistence.Database;

namespace StressTestImdb.Persistence.Seeders;
public class TitleBasicsSeeder
{
    public static void Seed(ImdbContext context)
    {
        if (context.TitleBasics.Any()) return;
        var titleBasics = File.ReadAllLines("title.basics.tsv");
        var titleBasicsList = new List<TitleBasics>();

        foreach (var titleBasic in titleBasics.Skip(1))
        {
            var titleBasicData = titleBasic.Split('\t');

            var titleBasicObj = new TitleBasics
            {
                tconst = titleBasicData[0],
                titleType = titleBasicData[1],
                primaryTitle = titleBasicData[2],
                originalTitle = titleBasicData[3],
                isAdult = titleBasicData[4] == "1",
                startYear = int.Parse(titleBasicData[5]),
                endYear = int.Parse(titleBasicData[6]),
                runtimeMinutes = int.Parse(titleBasicData[7]),
                genres = titleBasicData[8].Split(',')
            };

            titleBasicsList.Add(titleBasicObj);
        }

        context.TitleBasics.AddRange(titleBasicsList);
        context.SaveChanges();
    }
}
