using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Configurations;

public class ProductConfigurataion : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(c => c.Id).HasConversion(
            ProductId => ProductId.Value,
            dbId => ProductId.Of(dbId));

        builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
    }
}
