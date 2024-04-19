using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StressTestImdb.Domain.Entities;

namespace StressTestImdb.Mappers;

class TitleRatingsMapper : IEntityTypeConfiguration<TitleRating>
{
    public void Configure(EntityTypeBuilder<TitleRating> builder)
    {
        builder.ToTable("titleratings", "imdb");
        builder.HasKey(x => x.Tconst);
        builder.Property(x => x.Tconst).HasColumnName("tconst");
        builder.Property(x => x.AverageRating).HasColumnName("averageRating");
        builder.Property(x => x.NumVotes).HasColumnName("numVotes");
    }
}

