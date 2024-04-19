using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StressTestImdb.Domain.Entities;

namespace StressTestImdb.Mappers;

class TitleCrewMapper : IEntityTypeConfiguration<TitleCrew>
{
    public void Configure(EntityTypeBuilder<TitleCrew> builder)
    {
        builder.ToTable("titlecrew", "imdb");
        builder.HasKey(x => x.Tconst);
        builder.Property(x => x.Tconst).HasColumnName("tconst");
        builder.Property(x => x.Directors).HasColumnName("directors");
        builder.Property(x => x.Writers).HasColumnName("writers");
    }
}

