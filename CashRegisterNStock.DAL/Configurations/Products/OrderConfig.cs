using CashRegisterNStock.DAL.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashRegisterNStock.DAL.Configurations.Products
{
    class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.Status)
                .IsRequired()
                .HasConversion<string>();

            builder.HasMany(o => o.OrderLine)
                .WithOne(ol => ol.Order);
        }
    }
}
