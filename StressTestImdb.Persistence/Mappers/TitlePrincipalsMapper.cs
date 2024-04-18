using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StressTestImdb.Domain.Entities;

namespace StressTestImdb.Mappers;

class TitlePrincipalsMapper : IEntityTypeConfiguration<TitlePrincipals>
{
    public void Configure(EntityTypeBuilder<TitlePrincipals> builder)
    {
        builder.ToTable("title.principals");
        builder.HasKey(x => x.tconst);
        builder.Property(x => x.tconst).HasColumnName("tconst");
        builder.Property(x => x.ordering).HasColumnName("ordering");
        builder.Property(x => x.nconst).HasColumnName("nconst");
        builder.Property(x => x.category).HasColumnName("category");
        builder.Property(x => x.job).HasColumnName("job");
        builder.Property(x => x.characters).HasColumnName("characters");
    }
}

