using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StressTestImdb.Domain.Entities;

namespace StressTestImdb.Mappers;

class TitlePrincipalsMapper : IEntityTypeConfiguration<TitlePrincipals>
{
    public void Configure(EntityTypeBuilder<TitlePrincipals> builder)
    {
        builder.ToTable("titleprincipals", "imdb");
        builder.HasKey(x => x.Tconst);
        builder.Property(x => x.Tconst).HasColumnName("tconst");
        builder.Property(x => x.Ordering).HasColumnName("ordering");
        builder.Property(x => x.Nconst).HasColumnName("nconst");
        builder.Property(x => x.Category).HasColumnName("category");
        builder.Property(x => x.Job).HasColumnName("job");
        builder.Property(x => x.Characters).HasColumnName("characters");
    }
}

