using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StressTestImdb.Domain.Entities;

namespace StressTestImdb.Mappers;

class TitleCrewMapper : IEntityTypeConfiguration<TitleCrew>
{
    public void Configure(EntityTypeBuilder<TitleCrew> builder)
    {
        builder.ToTable("title.crew");
        builder.HasKey(x => x.tconst);
        builder.Property(x => x.tconst).HasColumnName("tconst");
        builder.Property(x => x.directors).HasColumnName("directors");
        builder.Property(x => x.writers).HasColumnName("writers");
    }
}

