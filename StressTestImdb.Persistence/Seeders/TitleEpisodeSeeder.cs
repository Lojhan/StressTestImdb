using StressTestImdb.Domain.Entities;
using StressTestImdb.Persistence.Database;

namespace StressTestImdb.Persistence.Seeders;
public class TitleEpisodeSeeder
{
    public static void Seed(ImdbContext context)
    {
        if (context.TitleEpisode.Any()) return;
        var titleEpisodes = File.ReadAllLines("title.episode.tsv");
        var titleEpisodesList = new List<TitleEpisode>();

        foreach (var titleEp in titleEpisodes.Skip(1))
        {
            var titleEpData = titleEp.Split('\t');

            var titleEpObj = new TitleEpisode
            {
                tconst = titleEpData[0],
                parentTconst = titleEpData[1],
                seasonNumber = int.Parse(titleEpData[2]),
                episodeNumber = int.Parse(titleEpData[3])
            };

            titleEpisodesList.Add(titleEpObj);
        }

        context.TitleEpisode.AddRange(titleEpisodesList);
        context.SaveChanges();
    }
}
