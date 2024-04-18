using StressTestImdb.Domain.Entities;
using StressTestImdb.Persistence.Database;

namespace StressTestImdb.Persistence.Seeders;
public class TitlePrincipalsSeeder
{
    public static void Seed(ImdbContext context)
    {
        if (context.TitlePrincipals.Any()) return;
        var titlePrincipals = File.ReadAllLines("title.principals.tsv");
        var titlePrincipalsList = new List<TitlePrincipals>();

        foreach (var titlePr in titlePrincipals.Skip(1))
        {
            var titlePrData = titlePr.Split('\t');

            var titlePrObj = new TitlePrincipals
            {
                tconst = titlePrData[0],
                ordering = int.Parse(titlePrData[1]),
                nconst = titlePrData[2],
                category = titlePrData[3],
                job = titlePrData[4],
                characters = titlePrData[5]
            };

            titlePrincipalsList.Add(titlePrObj);
        }

        context.TitlePrincipals.AddRange(titlePrincipalsList);
        context.SaveChanges();
    }
}
