using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StressTestImdb.Domain.Entities;

namespace StressTestImdb.Mappers;

class TitleRatingsMapper : IEntityTypeConfiguration<TitleRatings>
{
    public void Configure(EntityTypeBuilder<TitleRatings> builder)
    {
        builder.ToTable("title.ratings");
        builder.HasKey(x => x.tconst);
        builder.Property(x => x.tconst).HasColumnName("tconst");
        builder.Property(x => x.averageRating).HasColumnName("averageRating");
        builder.Property(x => x.numVotes).HasColumnName("numVotes");
    }
}

