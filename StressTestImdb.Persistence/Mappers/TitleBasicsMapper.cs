using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StressTestImdb.Domain.Entities;

namespace StressTestImdb.Mappers;


class TitleBasicsMapper : IEntityTypeConfiguration<TitleBasics>
{
    public void Configure(EntityTypeBuilder<TitleBasics> builder)
    {
        builder.ToTable("title_basics");
        builder.HasKey(x => x.Tconst);
        builder.Property(x => x.Tconst).HasColumnName("tconst");
        builder.Property(x => x.TitleType).HasColumnName("titleType");
        builder.Property(x => x.PrimaryTitle).HasColumnName("primaryTitle");
        builder.Property(x => x.OriginalTitle).HasColumnName("originalTitle");
        builder.Property(x => x.IsAdult).HasColumnName("isAdult");
        builder.Property(x => x.StartYear).HasColumnName("startYear");
        builder.Property(x => x.EndYear).HasColumnName("endYear");
        builder.Property(x => x.RuntimeMinutes).HasColumnName("runtimeMinutes");
        builder.Property(x => x.Genres).HasColumnName("genres");
    }
}

