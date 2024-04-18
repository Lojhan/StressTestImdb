using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StressTestImdb.Domain.Entities;

namespace StressTestImdb.Mappers;

class NameBasicsMapper : IEntityTypeConfiguration<NameBasics>
{
    public void Configure(EntityTypeBuilder<NameBasics> builder)
    {
        builder.ToTable("name.basics");
        builder.HasKey(x => x.nconst);
        builder.Property(x => x.nconst).HasColumnName("nconst");
        builder.Property(x => x.primaryName).HasColumnName("primaryName");
        builder.Property(x => x.birthYear).HasColumnName("birthYear");
        builder.Property(x => x.deathYear).HasColumnName("deathYear");
        builder.Property(x => x.primaryProfession).HasColumnName("primaryProfession");
        builder.Property(x => x.knownForTitles).HasColumnName("knownForTitles");
    }
}

