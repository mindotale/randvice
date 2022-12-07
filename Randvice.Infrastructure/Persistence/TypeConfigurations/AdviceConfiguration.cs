using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Randvice.Core.Advices;

namespace Randvice.Infrastructure.Persistence.TypeConfigurations;

public class AdviceConfiguration : IEntityTypeConfiguration<Advice>
{
    public void Configure(EntityTypeBuilder<Advice> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Text).IsRequired().HasMaxLength(256);
    }
}
