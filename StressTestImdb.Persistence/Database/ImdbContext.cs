using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
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
    public DbSet<TitleRating> TitleRatings { get; set; }
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
            .EnableSensitiveDataLogging()
            .Options;

        using var context = new ImdbContext(options);
        context.Database.Migrate();

        Console.WriteLine("Seeding database...");
        Console.WriteLine("Seeding TitleBasics...");
        TitleBasicsSeeder.SpawnSeeder(context);
        Console.WriteLine("Seeding TitleAkas...");
       

        Console.WriteLine("Database seeded successfully!");
    }
}

public class ImdbContextFactory : IDesignTimeDbContextFactory<ImdbContext>
{
    public ImdbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ImdbContext>();
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=TestDatabase;User=sa;Password=Your_password123;Persist Security Info=False;Encrypt=False");

        return new ImdbContext(optionsBuilder.Options);
    }
}
