using StressTestImdb.Domain.Entities;
using StressTestImdb.Persistence.Database;

namespace StressTestImdb.Persistence.Seeders;
public class NameBasicsSeeder
{
    public static void Seed(ImdbContext context)
    {
        if (context.NameBasics.Any()) return;
        var nameBasics = File.ReadAllLines("name.basics.tsv");
        
        foreach (var nameBasic in nameBasics.Skip(1)) 
            context.NameBasics.Add(NameBasics.FromCsv(nameBasic));        
        
        context.SaveChanges();
    }
}
