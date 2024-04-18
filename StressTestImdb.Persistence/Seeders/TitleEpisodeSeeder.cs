using StressTestImdb.Domain.Entities;
using StressTestImdb.Persistence.Database;

namespace StressTestImdb.Persistence.Seeders;
public class TitleEpisodeSeeder
{
    public static void Seed(ImdbContext context)
    {
        if (context.TitleEpisode.Any()) return;
        var titleEpisodes = File.ReadAllLines("title.episode.tsv");
        
        foreach (var titleEpisode in titleEpisodes.Skip(1))
            context.TitleEpisode.Add(TitleEpisode.FromCsv(titleEpisode));

        context.SaveChanges();
    }
}
