using CashRegisterNStock.DAL.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashRegisterNStock.DAL.Configurations.Products
{
    class OrderLineConfig : IEntityTypeConfiguration<OrderLine>
    {
        public void Configure(EntityTypeBuilder<OrderLine> builder)
        {
            builder.HasKey(ol => new { ol.OrderId, ol.ProductId });

            builder.Property(ol => ol.Quantity)
                .IsRequired();

            builder.Property(ol => ol.Price)
                .IsRequired();
        }
    }
}
