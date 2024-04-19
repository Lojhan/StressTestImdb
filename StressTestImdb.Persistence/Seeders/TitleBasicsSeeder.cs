using Microsoft.EntityFrameworkCore;
using StressTestImdb.Domain.Entities;
using StressTestImdb.Persistence.Database;

namespace StressTestImdb.Persistence.Seeders;
public class TitleBasicsSeeder
{
    public static void Seed(ImdbContext context)
    {
        Console.WriteLine("Seeding TitleBasics...");
        List<TitleBasics> titleBasics = [];
        
        while (true)
        {
            // log count
            string id = Guid.NewGuid().ToString();
            TitleBasics titleBasic = new(
                tconst: id,
                titleType: "movie",
                primaryTitle: "Movie Title",
                originalTitle: "Movie Title",
                isAdult: false,
                startYear: 2021,
                endYear: 2021,
                runtimeMinutes: 120,
                genres: ["Action, Adventure, Comedy"]
            );

            TitleAkas titleAkas = new(
                titleId: id,
                ordering: 1,
                title: "Movie Title",
                region: "US",
                language: "English",
                types: ["original"],
                attributes: ["imdbDisplay"],
                isOriginalTitle: true
            );

            TitleRating titleRating = new(
                tconst: id,
                averageRating: 8.5,
                numVotes: 100
            );

            TitleCrew titleCrew = new(
                tconst: id,
                directors: ["jamescameron"],
                writers: ["jamescameron"]
            );

            TitlePrincipals titlePrincipals = new(
                tconst: id,
                ordering: 1,
                nconst: "nm0000245",
                category: "actor",
                job: "actor",
                characters: ["John Doe"]
            );

            List<TitleEpisode> titleEpisodes = [];

            for (int i = 0; i < 10; i++)
            {
                TitleEpisode titleEpisode = new(
                    tconst: id,
                    parentTconst: id,
                    seasonNumber: 1,
                    episodeNumber: i
                );

                titleEpisodes.Add(titleEpisode);
            }

            titleBasic.TitleAkas = titleAkas;
            titleBasic.TitleRating = titleRating;
            titleBasic.TitleCrew = titleCrew;
            titleBasic.TitlePrincipals = [titlePrincipals];
            titleBasic.TitleEpisodes = titleEpisodes;

            titleBasics.Add(titleBasic);

            if (titleBasics.Count % 1000 == 0)
            {
                Console.WriteLine($"Seeding {titleBasics.Count} TitleBasics...");
                context.TitleBasics.AddRange(titleBasics);
                context.SaveChanges();
                titleBasics.Clear();
            }
        }

        context.TitleBasics.AddRange(titleBasics);
        context.SaveChanges();
    }

    public static void SpawnSeeder(ImdbContext context)
    {
        // spanwn a thread that will countinuously seeding the database

        Thread thread = new(() =>
        {
            while (true)
            {
                ImdbContextFactory factory = new();
                ImdbContext context = factory.CreateDbContext(null!);
                Seed(context);
                // send message to the console
                Console.WriteLine("Seeding database...");
                Thread.Sleep(1000);
            }
        });

        thread.Start();
    }

}
