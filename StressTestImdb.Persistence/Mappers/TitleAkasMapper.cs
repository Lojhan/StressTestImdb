using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StressTestImdb.Domain.Entities;

namespace StressTestImdb.Mappers;

class TitleAkasMapper : IEntityTypeConfiguration<TitleAkas>
{
    public void Configure(EntityTypeBuilder<TitleAkas> builder)
    {
        builder.ToTable("titleakas", "imdb");

        // the key is id + ordering
        builder.HasKey(x => new { x.TitleId, x.Ordering });

        builder.Property(x => x.TitleId).HasColumnName("titleId");
        builder.Property(x => x.Ordering).HasColumnName("ordering");
        builder.Property(x => x.Title).HasColumnName("title");
        builder.Property(x => x.Region).HasColumnName("region");
        builder.Property(x => x.Language).HasColumnName("language");
        builder.Property(x => x.Types).HasColumnName("types");
        builder.Property(x => x.Attributes).HasColumnName("attributes");
        builder.Property(x => x.IsOriginalTitle).HasColumnName("isOriginalTitle");
    }
}