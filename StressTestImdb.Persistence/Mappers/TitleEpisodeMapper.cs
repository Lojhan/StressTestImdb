using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StressTestImdb.Domain.Entities;

namespace StressTestImdb.Mappers;

class TitleEpisodeMapper : IEntityTypeConfiguration<TitleEpisode>
{
    public void Configure(EntityTypeBuilder<TitleEpisode> builder)
    {
        builder.ToTable("title.episode");
        builder.HasKey(x => x.tconst);
        builder.Property(x => x.tconst).HasColumnName("tconst");
        builder.Property(x => x.parentTconst).HasColumnName("parentTconst");
        builder.Property(x => x.seasonNumber).HasColumnName("seasonNumber");
        builder.Property(x => x.episodeNumber).HasColumnName("episodeNumber");
    }
}

