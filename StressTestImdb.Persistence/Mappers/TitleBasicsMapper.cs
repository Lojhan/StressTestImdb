using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StressTestImdb.Domain.Entities;

namespace StressTestImdb.Mappers;


class TitleBasicsMapper : IEntityTypeConfiguration<TitleBasics>
{
    public void Configure(EntityTypeBuilder<TitleBasics> builder)
    {
        builder.ToTable("titlebasics", "imdb");
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

        builder.HasOne(x => x.TitleAkas).WithOne(x => x.TitleBasics)
            .HasForeignKey<TitleAkas>(x => x.TitleId);

        builder.HasOne(x => x.TitleCrew).WithOne(x => x.TitleBasics).HasForeignKey<TitleCrew>(x => x.Tconst);
        builder.HasMany(x => x.TitleEpisodes).WithOne(x => x.TitleBasics).HasForeignKey(x => x.ParentTconst);
        builder.HasMany(x => x.TitlePrincipals).WithOne(x => x.TitleBasics).HasForeignKey(x => x.Tconst);
        builder.HasOne(x => x.TitleRating).WithOne(x => x.TitleBasics).HasForeignKey<TitleRating>(x => x.Tconst);
  
    }
}

