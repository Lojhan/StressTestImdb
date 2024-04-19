using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StressTestImdb.Domain.Entities;

namespace StressTestImdb.Mappers;

class TitleEpisodeMapper : IEntityTypeConfiguration<TitleEpisode>
{
    public void Configure(EntityTypeBuilder<TitleEpisode> builder)
    {
        builder.ToTable("titleepisode", "imdb");
        builder.HasKey(x => x.Tconst);
        builder.Property(x => x.Tconst).HasColumnName("tconst");
        builder.Property(x => x.ParentTconst).HasColumnName("parentTconst");
        builder.Property(x => x.SeasonNumber).HasColumnName("seasonNumber");
        builder.Property(x => x.EpisodeNumber).HasColumnName("episodeNumber");
    }
}

