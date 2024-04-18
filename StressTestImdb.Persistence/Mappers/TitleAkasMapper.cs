using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StressTestImdb.Domain.Entities;

namespace StressTestImdb.Mappers;

class TitleAkasMapper : IEntityTypeConfiguration<TitleAkas>
{
    public void Configure(EntityTypeBuilder<TitleAkas> builder)
    {
        builder.ToTable("title.akas");
        builder.HasKey(x => x.titleId);
        builder.Property(x => x.titleId).HasColumnName("titleId");
        builder.Property(x => x.ordering).HasColumnName("ordering");
        builder.Property(x => x.title).HasColumnName("title");
        builder.Property(x => x.region).HasColumnName("region");
        builder.Property(x => x.language).HasColumnName("language");
        builder.Property(x => x.types).HasColumnName("types");
        builder.Property(x => x.attributes).HasColumnName("attributes");
        builder.Property(x => x.isOriginalTitle).HasColumnName("isOriginalTitle");
    }
}