using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StressTestImdb.Domain.Entities;

namespace StressTestImdb.Mappers;

class TitleAkasMapper : IEntityTypeConfiguration<TitleAkas>
{
    public void Configure(EntityTypeBuilder<TitleAkas> builder)
    {
        builder.ToTable("title_akas");
        builder.HasKey(x => x.TitleId);
        builder.Property(x => x.TitleId).HasColumnName("titleId");
        builder.Property(x => x.Ordering).HasColumnName("ordering");
        builder.Property(x => x.Title).HasColumnName("title");
        builder.Property(x => x.Region).HasColumnName("region");
        builder.Property(x => x.Language).HasColumnName("language");
        builder.Property(x => x.Types).HasColumnName("types");
        builder.Property(x => x.Attributes).HasColumnName("attributes");
        builder.Property(x => x.IsOriginalTitle).HasColumnName("isOriginalTitle");

        builder.HasOne(x => x.TitleBasics).WithMany().HasForeignKey(x => x.TitleId);
        builder.HasOne(x => x.TitleCrew).WithMany().HasForeignKey(x => x.TitleId);
        builder.HasMany(x => x.TitleEpisodes).WithOne(x => x.TitleAkas).HasForeignKey(x => x.ParentTconst);
        builder.HasMany(x => x.TitlePrincipals).WithOne(x => x.TitleAkas).HasForeignKey(x => x.Tconst);
        builder.HasOne(x => x.TitleRating).WithOne(x => x.TitleAkas).HasForeignKey<TitleRating>(x => x.Tconst);
    }
}