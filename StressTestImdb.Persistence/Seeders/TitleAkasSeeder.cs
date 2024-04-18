using StressTestImdb.Domain.Entities;
using StressTestImdb.Persistence.Database;

namespace StressTestImdb.Persistence.Seeders;

public class TitleAkasSeeder
{
    public static void Seed(ImdbContext context)
    {
        if (context.TitleAkas.Any()) return;
        var titleAkas = File.ReadAllLines("title.akas.tsv");
        var titleAkasList = new List<TitleAkas>();


        foreach (var titleAka in titleAkas.Skip(1))
        {
            var titleAkaData = titleAka.Split('\t');

            var titleAkaObj = new TitleAkas
            {
                titleId = titleAkaData[0],
                ordering = int.Parse(titleAkaData[1]),
                title = titleAkaData[2],
                region = titleAkaData[3],
                language = titleAkaData[4],
                types = titleAkaData[5].Split(','),
                attributes = titleAkaData[6].Split(','),
                isOriginalTitle = titleAkaData[7] == "1"
            };

            titleAkasList.Add(titleAkaObj);
        }

        context.TitleAkas.AddRange(titleAkasList);
        context.SaveChanges();
    }
}
