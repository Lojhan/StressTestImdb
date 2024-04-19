using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StressTestImdb.Domain.Entities;

namespace StressTestImdb.Mappers;

class NameBasicsMapper : IEntityTypeConfiguration<NameBasics>
{
    public void Configure(EntityTypeBuilder<NameBasics> builder)
    {
        builder.ToTable("namebasics", "imdb");
        builder.HasKey(x => x.Nconst);
        builder.Property(x => x.Nconst).HasColumnName("nconst");
        builder.Property(x => x.PrimaryName).HasColumnName("primaryName");
        builder.Property(x => x.BirthYear).HasColumnName("birthYear");
        builder.Property(x => x.DeathYear).HasColumnName("deathYear");
        builder.Property(x => x.PrimaryProfession).HasColumnName("primaryProfession");
        builder.Property(x => x.KnownForTitles).HasColumnName("knownForTitles");
    }
}

