using StressTestImdb.Domain.Entities;
using StressTestImdb.Persistence.Database;

namespace StressTestImdb.Persistence.Seeders;
public class TitleBasicsSeeder
{
    public static void Seed(ImdbContext context)
    {
        if (context.TitleBasics.Any()) return;
        var titleBasics = File.ReadAllLines("title.basics.tsv");
        
        foreach (var titleBasic in titleBasics.Skip(1))
            context.TitleBasics.Add(TitleBasics.FromCsv(titleBasic));
            
        context.SaveChanges();
    }
}
