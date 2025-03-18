using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Configurations;

public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
{
    public void Configure(EntityTypeBuilder<OrderItem> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(c => c.Id).HasConversion(
             OrderItemId => OrderItemId.Value,
             dbId => OrderItemId.of(dbId));

        builder.HasOne<Product>()
                    .WithMany()
                    .HasForeignKey(x => x.ProductId);

        builder.Property(x => x.Price).IsRequired();

        builder.Property(x => x.Quantity).IsRequired();
    }
}
