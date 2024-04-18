using StressTestImdb.Domain.Entities;
using StressTestImdb.Persistence.Database;

namespace StressTestImdb.Persistence.Seeders;
public class NameBasicsSeeder
{
    public static void Seed(ImdbContext context)
    {
        if (context.NameBasics.Any()) return;
        var nameBasics = File.ReadAllLines("name.basics.tsv");
        var nameBasicsList = new List<NameBasics>();

        foreach (var nameBasic in nameBasics.Skip(1))
        {
            var nameBasicData = nameBasic.Split('\t');

            var nameBasicObj = new NameBasics
            {
                nconst = nameBasicData[0],
                primaryName = nameBasicData[1],
                birthYear = int.Parse(nameBasicData[2]),
                deathYear = int.Parse(nameBasicData[3]),
                primaryProfession = nameBasicData[4].Split(','),
                knownForTitles = nameBasicData[5].Split(',')
            };

            nameBasicsList.Add(nameBasicObj);
        }

        context.NameBasics.AddRange(nameBasicsList);
        context.SaveChanges();
    }
}
