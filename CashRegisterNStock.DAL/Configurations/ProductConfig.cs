using CashRegisterNStock.DAL.Entities.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashRegisterNStock.DAL.Configurations
{
    class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(p => p.Price)
                .IsRequired();

            builder.Property(p => p.Stock)
                .IsRequired();

            builder.HasOne(p => p.TypeProduct)
                .WithMany(t => t.Products)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
