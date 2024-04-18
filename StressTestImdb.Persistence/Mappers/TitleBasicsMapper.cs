using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StressTestImdb.Domain.Entities;

namespace StressTestImdb.Mappers;


class TitleBasicsMapper : IEntityTypeConfiguration<TitleBasics>
{
    public void Configure(EntityTypeBuilder<TitleBasics> builder)
    {
        builder.ToTable("title.basics");
        builder.HasKey(x => x.tconst);
        builder.Property(x => x.tconst).HasColumnName("tconst");
        builder.Property(x => x.titleType).HasColumnName("titleType");
        builder.Property(x => x.primaryTitle).HasColumnName("primaryTitle");
        builder.Property(x => x.originalTitle).HasColumnName("originalTitle");
        builder.Property(x => x.isAdult).HasColumnName("isAdult");
        builder.Property(x => x.startYear).HasColumnName("startYear");
        builder.Property(x => x.endYear).HasColumnName("endYear");
        builder.Property(x => x.runtimeMinutes).HasColumnName("runtimeMinutes");
        builder.Property(x => x.genres).HasColumnName("genres");
    }
}

