using Microsoft.EntityFrameworkCore;
using StressTestImdb.Domain.Entities;
using StressTestImdb.Mappers;
using StressTestImdb.Persistence.Seeders;

namespace StressTestImdb.Persistence.Database;

public class ImdbContext(DbContextOptions<ImdbContext> options) : DbContext(options)
{
    public DbSet<TitleAkas> TitleAkas { get; set; }
    public DbSet<TitleBasics> TitleBasics { get; set; }
    public DbSet<TitleCrew> TitleCrew { get; set; }
    public DbSet<TitleEpisode> TitleEpisode { get; set; }
    public DbSet<TitlePrincipals> TitlePrincipals { get; set; }
    public DbSet<TitleRatings> TitleRatings { get; set; }
    public DbSet<NameBasics> NameBasics { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new TitleAkasMapper());
        modelBuilder.ApplyConfiguration(new TitleBasicsMapper());
        modelBuilder.ApplyConfiguration(new TitleCrewMapper());
        modelBuilder.ApplyConfiguration(new TitleEpisodeMapper());
        modelBuilder.ApplyConfiguration(new TitlePrincipalsMapper());
        modelBuilder.ApplyConfiguration(new TitleRatingsMapper());
        modelBuilder.ApplyConfiguration(new NameBasicsMapper());
    }

    public static void MigrateAndSeed(string connectionString)
    {
        var options = new DbContextOptionsBuilder<ImdbContext>()
            .UseSqlServer(connectionString)
            .Options;

        using var context = new ImdbContext(options);
        context.Database.Migrate();

        Console.WriteLine("Seeding database...");
        Console.WriteLine("Seeding TitleAkas...");
        TitleAkasSeeder.Seed(context);
        Console.WriteLine("Seeding TitleBasics...");
        TitleBasicsSeeder.Seed(context);
        Console.WriteLine("Seeding TitleCrew...");
        TitleCrewSeeder.Seed(context);
        Console.WriteLine("Seeding TitleEpisode...");
        TitleEpisodeSeeder.Seed(context);
        Console.WriteLine("Seeding TitlePrincipals...");
        TitlePrincipalsSeeder.Seed(context);
        Console.WriteLine("Seeding TitleRatings...");
        TitleRatingsSeeder.Seed(context);
        Console.WriteLine("Seeding NameBasics...");
        NameBasicsSeeder.Seed(context);

        Console.WriteLine("Database seeded successfully!");
    }
}