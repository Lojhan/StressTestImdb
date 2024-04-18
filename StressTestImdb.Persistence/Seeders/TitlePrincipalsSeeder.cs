using StressTestImdb.Domain.Entities;
using StressTestImdb.Persistence.Database;

namespace StressTestImdb.Persistence.Seeders;
public class TitlePrincipalsSeeder
{
    public static void Seed(ImdbContext context)
    {
        if (context.TitlePrincipals.Any()) return;
        var titlePrincipals = File.ReadAllLines("title.principals.tsv");

        foreach (var titlePrincipal in titlePrincipals.Skip(1))
            context.TitlePrincipals.Add(TitlePrincipals.FromCsv(titlePrincipal));
            
        context.SaveChanges();
    }
}
